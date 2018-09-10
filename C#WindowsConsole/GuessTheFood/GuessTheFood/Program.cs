using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheFood
{
    class Food
    {
        int randomPick = 0;
        int guessAttempt = 0;
        string userInput = "";
        string[] choice = { "pizza", "pasta", "salmon", "steak", "miso" };
        Random randomNum = new Random();

        public void Store()
        {

            randomPick = randomNum.Next(choice.Length);

            Console.Write(" Guess which food I like to take?...");
            //retrieve data from array
            for (int i = 0; i < choice.Length; i++)  
            {
                if (i == (choice.Length - 1))
                    Console.Write("or " + choice[i] + "? ");
                else
                    Console.Write(choice[i] + ", ");
            }
            // user inputs the guess
            for (int j = 0; j < 2; j++)
            {
                userInput = Console.ReadLine();
                //if guess is not correct
                if (userInput != choice[randomPick])
                {
                    guessAttempt++;
                    //if guessing attempt is more than 3 chances
                    if (guessAttempt > 3)
                    {
                        Console.WriteLine(" Guess Limit exceeded");
                        break;
                    }
                    else
                    {

                    }
                    Console.WriteLine(" Guess Wrong. Try again!");
                    Console.WriteLine(" You have " + (3 - guessAttempt) + " trial(s) left");
                    Console.WriteLine(" Press enter to continue...");
                    Console.ReadLine();
                    Store();
                }

                else
                {
                    Console.WriteLine(" Congratulations! You guess it right!");
                    break;
                }
                Console.ReadKey();
            }
        }

        class Program
        {
            static void Main()
            {
                Food order = new Food();
                order.Store();
            }
        }

    }
}
