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

            List<int[]> previousGuessList = new List<int[]>();
            List<string> previousResults = new List<string>();


            while (attemptCount <= 10)
            //while (userGuess != winningNumber && attemptCount <= 10)
            {
                userGuess = userNumberChoice(previousGuessList, previousResults);
                previousGuessList.Add(userGuess);
                results = resultsDisplay(userGuess, winningNumber);
                previousResults.Add(results);

                Console.Clear();

                displayPreviousResults(previousGuessList, previousResults);

                attemptCount++;

                if (arrayEquality(userGuess, winningNumber))
                {
                    Console.WriteLine("Winner!");
                    Console.WriteLine("Congratulation, Press Enter To Exit Program");
                    Console.ReadLine();
                    break;

                }

              //  Console.WriteLine($"Press Enter for Guess {attemptCount}");
               // Console.ReadLine();
                Console.Clear();

                displayPreviousResults(previousGuessList, previousResults);

                Console.WriteLine($"Guess {attemptCount}");
            }
                Console.WriteLine("Sorry! Thanks for Playing! Please Come Again!");
            
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
        static int[] userNumberChoice(List<int[]> previousGuess, List<string> previousResult)
        {
            //Array to hold the guess; list to choose from
            int[] numberGuess = new int[4];
            List<int> digitChoice = new List<int>() { 1, 2, 3, 4, 5, 6 };

            //display current number (digit-by-digit)
            for (int i = 0; i < 4; i++)
            {
                //Provide Remaining Choice 

                Console.Write("Choose from the Following Digits: ");

                foreach (int remainingDigit in digitChoice)
                {
                    Console.Write(remainingDigit);
                }

                //Prompt for input
                Console.WriteLine("\nChoose a Digit and Press Enter");
                Console.Write("Your Number: ");

                foreach (int number in numberGuess)
                {
                    if (number != 0)
                    {
                        Console.Write(number);
                    }
                }

                bool success = false;
                int goodValue = 0;
                success = Int32.TryParse(Console.ReadLine(), out goodValue);

                while (!success || !digitChoice.Contains(goodValue))
                {
                    Console.WriteLine("Invalid Input, Please Choose an availabe digit from the list");
                    success = Int32.TryParse(Console.ReadLine(), out goodValue);
                }

                numberGuess[i] = goodValue;
                digitChoice.Remove(numberGuess[i]);


                Console.Clear();

                displayPreviousResults(previousGuess, previousResult);

                if (previousGuess.Count > 0)
                {
                    Console.WriteLine($"Guess: {previousGuess.Count + 1}");
                }

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

        static void displayPreviousResults(List<int[]> previousGuess, List<string> previousResult)
        {
            int guessCount = 1;

            if (previousGuess.Count > 0)
            {
                for (int j = 0; j < previousGuess.Count; j++)
                {
                    Console.WriteLine($"Guess {guessCount}");
                    Console.WriteLine(String.Join("", Array.ConvertAll<int, String>(previousGuess[j], Convert.ToString)));
                    Console.WriteLine(previousResult[j]);
                    guessCount++;
                }
            }
        }
        static bool arrayEquality(int[] intArray1, int[] intArray2)
        {
            if (intArray1.Length == intArray2.Length)
            {
                for (int i = 0; i < intArray1.Length; i++)
                {
                    if (intArray1[i] == intArray2[i])
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }
            }
            return false;
        }
    }
}