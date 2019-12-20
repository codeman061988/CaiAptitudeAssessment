using System;

namespace CaiAptitudeAssessment.Task1
{
    class Program
    {
        /// <summary>
        /// Main program entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Display title
            Console.WriteLine("Task 1 - problem solving demo\r");
            Console.WriteLine("------------------------------\n");

            // Ask the user to enter a number, which correlates to the problem numbers in Task 1 requirements
            Console.WriteLine("Type a problem number from the following list, then press enter:");
            Console.WriteLine("\n\t1 - Take any sentence in a String and reverse every word");
            Console.WriteLine("\n\t2 - Define two Integer (32bit) variables and values of X=72 and Y=59, ");
            Console.WriteLine("\t    now swap the values of X and Y without declaring any new variables,");
            Console.WriteLine("\t    use only the two existing X and Y variables.");
            Console.WriteLine("\n\t3 - Find the pattern “[Number1, Number2]” in any given String and get ");
            Console.WriteLine("\t    the Integer (32bit) values for Number1 and Number2.");
            Console.Write("\nYour choice: ");

            try
            {
                // Declare / initialize variable with user input choice
                var userInput = Console.ReadLine();

                // Use a switch statement to read user input and decide next steps
                switch (userInput)
                {
                    // Case if user chooses option 1
                    case "1":
                        HandleOption1();
                        break;

                    // Case if user chooses option 2
                    case "2":
                        HandleOption2();
                        break;

                    // Case if user chooses option 3
                    case "3":
                        HandleOption3();
                        break;

                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions, which could bubble up from any lower level methods
                WriteExceptionDetails(ex);
            }
            finally
            {
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }

        }

        /// <summary>
        /// Handles Option 1 of the main menu
        /// </summary>
        private static void HandleOption1()
        {
            // Ask the user to provide a sentence for the first problem
            Console.WriteLine("\n\nYou chose problem 1. Now, give me a sentence and I'll reverse every word! (press enter after typing it out)");
            Console.WriteLine("\nYour sentence: ");

            // Declare / initialize variable with user input sentence
            string sentenceInput = Console.ReadLine();

            // Invoke the method which will be performing the operation, located in the Core class
            // We need to pass the input sentence to the method. 
            // We'll initiale a new variable and assign its value as the result of the method invokation
            var result = Core.ReverseStringSentence(sentenceInput);

            // Once the result is processed, display it back to the user, along with where in the solution to find the source code
            Console.WriteLine("\n\nHere is the result:");
            Console.WriteLine($"\n{result}");
            Console.WriteLine("\n\nFor the solution to this problem, see the ReverseStringSentence method in Core.cs");
            Console.ReadLine();
        }

        /// <summary>
        /// Handles Option 2 of the main menu
        /// </summary>
        private static void HandleOption2()
        {
            // Declare the 2 variables used for this problem
            int x = 72;
            int y = 59;

            // Ask the user to provide a sentence for the first problem
            Console.WriteLine($"\n\nYou chose problem 2. Assuming X = {x} and Y = {y}, the logic for this problem will now swap values without declaring a new variable. (Press Enter)");
            Console.ReadLine();

            // Perform the process and display the results
            var result = Core.SwapIntValues(x, y);

            // Retrieve new X value
            x = result.Item1;

            // retrieve new Y value
            y = result.Item2;

            Console.WriteLine($"\nAlright, the result is X = {x} and Y = {y}");
            Console.WriteLine("\n\nFor the solution to this problem, see the SwapIntValues method in Core.cs");
            Console.ReadLine();

        }

        /// <summary>
        /// Handles Option 3 of the main menu
        /// </summary>
        private static void HandleOption3()
        {
            // Declare / initialize variable for input string, from which values will be extracted
            string inputValue = "\"The way to get started is to [45,46] quit talking and begin doing.\"";

            // Ask the user to provide a sentence for the first problem
            Console.WriteLine("\n\nYou chose problem 3. The string from which our value will be extracted is listed below:");
            Console.WriteLine(inputValue);
            Console.WriteLine("\n\nPress enter to parse");
            Console.ReadLine();

            var result = Core.ExtractIntsFromStringPattern(inputValue);

            Console.WriteLine($"\nAlright, the result is Number1 = {result.Item1} and Number2 = {result.Item2}");
            Console.WriteLine("\n\nFor the solution to this problem, see the ExtractIntsFromStringPattern method in Core.cs");
            Console.ReadLine();
        }

        /// <summary>
        /// Handles output of exception details, should and error occur
        /// </summary>
        /// <param name="ex"></param>
        private static void WriteExceptionDetails(Exception ex)
        {
            // Display exception details to the user
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("Whoops! We ran into an issue while attempting to process your input. Here are the details:");
            Console.WriteLine(ex.ToString());
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine(Environment.NewLine);
            Console.ReadLine();
        }

    }
}
