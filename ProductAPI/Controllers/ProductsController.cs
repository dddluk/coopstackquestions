
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductAPI.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        Product[] products = new Product[]
       {
            new Product { Id = 1, Name = "Mouse", Brand = "Logitech", Price = 20 },
            new Product { Id = 2, Name = "XBox", Brand = "MicroSoft", Price = 450},
            new Product { Id = 3, Name = "Laptop", Brand = "Lenovo", Price = 900 }
       };

        /* public IEnumerable<Product> GetAllProducts()
         {
             return products;
         }*/

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        /* public IHttpActionResult GetProduct(int id)
         {
             var product = products.FirstOrDefault((p) => p.Id == id);
             if (product == null)
             {
                 return NotFound();
             }
             return Ok(product);
         }*/

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductsByBrand(string brand)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Brand, brand, StringComparison.OrdinalIgnoreCase));
        }

        //Create an item
       /* public Product PostProduct(Product item)
        {
            item = repository.Add(item);
            return item;
        }*/

        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //Update an item
        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //Delete an item
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }

        /* public IHttpActionResult Delete(int id)
         {
             if (id <= 0)
                 return BadRequest("Not a valid product id");

             var product = products.FirstOrDefault((p) => p.Id == id);
             if (product == null)
             {
                 return NotFound();
             }
             return Ok();
         }*/


        /* [HttpDelete]
         public IHttpActionResult Delete([FromUri] int ID, [FromBody] String name)
         {
             return Ok(products);
         }*/
    }
}
