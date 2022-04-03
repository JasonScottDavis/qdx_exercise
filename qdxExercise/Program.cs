using System;
using System.Collections.Generic;



namespace qdxExercise
{
    class Program
    {

        //Questions removed, going with assumptions noted in previous commits. Following comment remains relevant
        //Note: Confirm with Quadax before you submit. Working on the assumption that they will pick one at a time and only one per digit

        static void Main(string[] args)
        {

            int[] winningNumber = generateWinningNumber();
            int[] userGuess = new int[4];
            int attemptCount = 1;
            string results = "";



            while (userGuess != winningNumber && attemptCount <= 10)
            {
                userGuess = userNumberChoice();

                results = resultsDisplay(userGuess, winningNumber);

                Console.Clear();
                Console.WriteLine($"Attempt: {attemptCount}");
                Console.WriteLine("Your Guess Was: " + String.Join("", Array.ConvertAll<int, String>(userGuess, Convert.ToString)));
                Console.WriteLine($"Your Results: {results}");

                attemptCount++;


                if (attemptCount < 10)
                {
                    Console.WriteLine($"Press Enter for Guess {attemptCount}");
                    Console.ReadLine();
                }
                else if(attemptCount == 10)
                {
                    Console.WriteLine($"Press Enter for Guess Last Attempt!");
                    Console.ReadLine();
                }
            }

            if(userGuess == winningNumber)
            {
                Console.WriteLine("Winner!");
            }

            else if (attemptCount >= 10)
            {
                Console.WriteLine("Sorry! Thanks for Playing! Please Come Again!");
            }
        }


        //Changing to Methods, Cleaning Up. 

        //---------------Randomly Generate a 4 digit number; Each digit "between numbers 1 and 6" ------------------
        static int[] generateWinningNumber()
        {
            //Instantiate an array to hold the winning number  
            int[] numberWinning = new int[4];

            //Populate array - Duplicates not Allowed
            int[] digits = new int[] { 1, 2, 3, 4, 5, 6 };
            int randomDigit = new Random().Next(0, 6);

            for (int i = 0; i < 4; i++)
            {
                //Zero takes the place of used digits, loop continues until it finds an unused digit
                while (digits[randomDigit] == 0)
                {
                    randomDigit = new Random().Next(0, 6);
                }
                //Add digit to array that represents the winning number
                numberWinning[i] = digits[randomDigit];

                //Set used digit to 0;
                digits[randomDigit] = 0;
            }
            return numberWinning;
        }


        //Prompts user to select a four digit number, one at a time to mimic the app
        static int[] userNumberChoice()
        {

            //Array to hold the map, list to choose from

            int[] numberGuess = new int[4];
            List<int> digitChoice = new List<int>() { 1, 2, 3, 4, 5, 6 };

            List<int[]> pastGuess = new List<int[]>();
            List<string> pastResults = new List<string>();


            //display current number (digit-by-digit)
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Your Number: ");

                foreach (int number in numberGuess)
                {
                    if (number != 0)
                    {
                        Console.Write(number);
                    }
                }
                //Provide Remaining Choice 
                Console.Write("\nChoose from the Following Digits: ");

                foreach (int remainingDigit in digitChoice)
                {
                    Console.Write(remainingDigit);
                }

                //Prompt for input
                Console.WriteLine("\nChoose a Digit and Press Enter");

                //To Do: Limit choices and errors

                
                numberGuess[i] = Int32.Parse(Console.ReadLine());
                digitChoice.Remove(numberGuess[i]);
                Console.Clear();


            }


            return numberGuess;

        }

        //Calculate results of the current guess (Note: Need to fix order: + first, - second, blank last)
        static string resultsDisplay(int[] userGuess, int[] winningNumber)
        {
            string[] results = new string[4];
            string resultString = "";

            //Compare guess to winning number
            for (int i = 0; i < userGuess.Length; i++)
            {
                //Plus sign for each if it is in the right place
                if (userGuess[i] == winningNumber[i])
                {
                    results[i] = "+";
                }
                //minus sign for each in the answer, but not in the right place
                else
                {
                    foreach (int numWin in winningNumber)
                    {
                        if (numWin == userGuess[i])
                        {
                            results[i] += "-";
                        }
                    }
                }
            }
            //Sort '+' first, then '-', then ''
            Array.Sort(results);
            Array.Reverse(results);
            foreach (string result in results)
            {
                resultString += result;
            }
            //return resultsString for use
            return resultString;
        }
    }
}