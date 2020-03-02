using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Program
    {
        static void Main(string[] args)
        {
            // greeting and explaination
            Console.WriteLine("This is a flashcard program.");
            Console.WriteLine("How many flashcards would you like to create?");
            int maxCards = Convert.ToInt32(Console.ReadLine());

            // create flashcards, max cards is what they entered, 2 is 1 front and 1 back
            string[,] flashcards = new string[maxCards, 2];

            Console.WriteLine("\nYou will now fill out the front and backs of your cards");
            Console.WriteLine("When using this program your answers must match what you enter here for the back perfectly so watch out for typos!");

            // for every card number (first number in [,]) ask what they want on the front (0) and the back (1) (second number in [,])
            for (int cardNumber = 0; cardNumber < maxCards; cardNumber++)
            {
                Console.WriteLine("\nCard Number " + cardNumber + ":");
                Console.WriteLine("What would you like on the front of the card?");
                // all fronts are 0 
                flashcards[cardNumber, 0] = Console.ReadLine();
                // all backs are 1
                Console.WriteLine("What would you like on the back of the card?");
                flashcards[cardNumber, 1] = Console.ReadLine();
            }
            
            Console.WriteLine("\nAll of your flashcards have been created.");
            Console.WriteLine("You can now go through them.");
            Console.WriteLine("Flashcards you get incorrectly will be moved to the top of the stack on replay.");
            Console.WriteLine("Flashcards you get correctly will be moved to the bottom of the stack on replay.");
            Console.WriteLine("Press any key to begin");
            Console.ReadLine();

            // this variable controls the loop, it will switch to false if they select no at the end
            bool keepGoing = true;
            while (keepGoing == true)
            {
                // create temporary string array for rearranging
                string[,] temp = new string[maxCards, 2];
                // fill temp array with "" to make it easier to search for open slots
                for (int tempCardNumber = 0; tempCardNumber < maxCards; tempCardNumber++)
                {
                    for (int tempWord = 0; tempWord < 2; tempWord++)
                    {
                        temp[tempCardNumber, tempWord] = "";
                    }
                }
                // for loop to display every flash card
                for (int cardNumber = 0; cardNumber < maxCards; cardNumber++)
                {
                    // prints out front of flash card
                    Console.WriteLine(flashcards[cardNumber, 0]);
                    string answer = Console.ReadLine().ToLower();
                    // if their answer matches the back of the card
                    if (answer == flashcards[cardNumber, 1])
                    {
                        Console.WriteLine("You are Correct!");
                        // for loop counting backwards to find last open spot
                        for (int tempCardNumber = maxCards - 1; tempCardNumber >= 0; tempCardNumber--)
                        {
                            // if they are correct find the last open spot in the array
                            // this puts cards they know better at the bottom of the stack
                            if (temp[tempCardNumber, 0] == "")
                            {
                                // copy info from flashcard to last open temp card
                                temp[tempCardNumber, 0] = flashcards[cardNumber, 0];
                                temp[tempCardNumber, 1] = flashcards[cardNumber, 1];
                                // break out of this loop or the same flashcard will be copied to every spot in temp array
                                break;
                            }
                        }
                    }
                    // if it does not match
                    else
                    {
                        Console.WriteLine("That is incorrect.");
                        Console.WriteLine("The correct answer is " + flashcards[cardNumber, 1]);
                        // for loop counting forwards to find first open spot
                        for (int tempCardNumber = 0; tempCardNumber < 5; tempCardNumber++)
                        {
                            // if they are wrong find the first open spot from the beginning of the temporary array
                            // this puts cards they don't know as well at the top of the stack
                            if (temp[tempCardNumber, 0] == "")
                            {
                                // copy info from flashcard to first open temp card
                                temp[tempCardNumber, 0] = flashcards[cardNumber, 0];
                                temp[tempCardNumber, 1] = flashcards[cardNumber, 1];
                                // break out of this loop or the same flashcard will be copied to every spot in temp array
                                break;
                            }
                        }
                    }
                }
                // copy the temporary array to the main flashcard array so the flashcards go in order from cards gotten wrong to cards gotten right
                for (int row = 0; row < maxCards; row++)
                {
                    for (int column = 0; column < 2; column++)
                    {
                        flashcards[row, column] = temp[row, column];
                    }
                }
                /* this shows the array after it is copied for testing purposes
                for (int row = 0; row < maxCards; row++)
                {
                    for (int column = 0; column < 2; column++)
                    {
                        Console.WriteLine(flashcards[row, column]);
                    }
                } */

                // see if they want to go agin
                Console.WriteLine("Would you like to go through your flashcards again? yes/no");
                string again = Console.ReadLine();
                // switch keep going to false if they say no
                if (again.Contains("n"))
                {
                    keepGoing = false;
                }
                
            }
        }
    }
}
