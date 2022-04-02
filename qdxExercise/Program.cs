using System;
using System.Collections.Generic;

namespace qdxExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            //---------------Randomly Generate a 4 digit number; Each digit "between numbers 1 and 6" ------------------
            //Questions:
            //Do all digits need to be unique?
                //Based on mastermind, assuming yes. 
            //Are the 1-6 digits inclusive?
                //Based on mastermind, assuming yes.

            //Thoughts: Store in an Array. Easy to index and compare. Easy to loop through
            
            
            //Instantiate an array to hold the winning number  
            int[] numberWinning = new int[4];

            //Populate array - Duplicates not Allowed
            int[] digits = new int[] { 1, 2, 3, 4, 5, 6 };
            int randomDigit = new Random().Next(0, 6);
           
            for (int i = 0; i < 4; i++)
            {
                while (digits[randomDigit] == 0)
                {
                    randomDigit = new Random().Next(0, 6);
                }
                numberWinning[i] = digits[randomDigit];
                digits[randomDigit] = 0;
            }

            //Preview Number
            string checkJoin = String.Join("", Array.ConvertAll<int, String>(numberWinning, Convert.ToString));
            Console.WriteLine("Winning Number: " + checkJoin);







            //allow player to input a combination of 4 digits
            //Starting to think moving to all lists is the right move
            

            int[] numberGuess = new int[4];

            List<int> digitChoice = new List<int>() { 1, 2, 3, 4, 5, 6 };
                

            for (int i = 0; i < 4; i++)
            
            {
                foreach (int remainingDigit in digitChoice)
                {
                    Console.Write(remainingDigit);
                }
                
                Console.WriteLine("\nYour Choice?");
                
                //Will have to limit choices to remaining digits
                numberGuess[i] = Int32.Parse(Console.ReadLine());
                digitChoice.Remove(numberGuess[i]);

                string checkJoin2 = String.Join("", Array.ConvertAll<int, String>(numberGuess, Convert.ToString));
                Console.WriteLine(checkJoin2);

            }


            //Choose 4 of the 6 numbers
            //Display All 6
            //Allow Choice 
            //Display remaining
            //Allow choice ...





            //error check inputs

            //question: should the user be able to choose only 1 of each digit? -Assuming yes

            //question: should I ask for a 4 digit number from the user or only one at a time. -Assuming one at a time

            //Note: Confirm with Quadax before you submit. Working on the assumption that they will pick one at a time and only one per digit


            //compare to number and return
            //  count up included and in the right spot for a +
            //  count up included and not in the right spot for a -
            //  return result
            //+ signs come first, - signs second

            //Allow 10 Chances

            //Example: 3512
            //Guess: 5318 should return +--
            //Next Guess: 1356 should return +--
            //Next Guess: 3152 should return +++-








        }
    }
}
