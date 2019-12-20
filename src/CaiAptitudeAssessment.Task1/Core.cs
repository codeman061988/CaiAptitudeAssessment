using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CaiAptitudeAssessment.Task1
{
    /// <summary>
    /// Provides core functonality of problem set in Task 1
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// Takes any sentence in a string and reverses every word
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string ReverseStringSentence(string sentence)
        {
            // Break sentence string into an array of individuals word strings
            string[] words = sentence.Split(" ");

            // Declare new output variable
            string result = "";

            // Iterate through array of words using for loop
            // This 'for' loop says that as long as the current iteration is greater than or equal to 0 index, continue.
            // The loop sets the current iteration at the end of the array.
            // It also say decrement, which means go backwards in the array.
            for (int i = words.Length - 1; i >= 0; i--)
            {
                // Append current iteration of 'words' to the result string
                // We also need to add a space, since we used string space as a delimiter to identify the words in a sentence
                result += $"{words[i]} ";
            }

            // Return our result to the invoking caller
            return result;
        }

        /// <summary>
        /// Defines two Integer (32bit) variables and values of X=72 and Y=59, 
        /// swaps the values of X and Y without declaring any new variables, 
        /// uses only the two existing X and Y variables
        /// </summary>
        /// <param name="valueX"></param>
        /// <param name="valueY"></param>
        /// <returns>x, y</returns>
        public static (int, int) SwapIntValues(int valueX, int valueY)
        {
            // We can swap the values of the two variables by using some basic mathematics.
            // By adding and subtracting, the values are "hitching a ride"; so to speak, on each variable as they are being swapped

            // First, add the value of Y to the Value of X
            valueX = valueX + valueY;

            // Now, subtract the value of X from the value of Y
            valueY = valueX - valueY;

            // Finally, subtract the new value of X from the new value of Y to complete the transfer
            valueX = valueX - valueY;

            // Return our result to the invoking caller
            return (valueX, valueY);
        }

        /// <summary>
        /// Finds the pattern “[Number1, Number2]” in any given String and gets the Integer (32bit) values for Number1 and Number2
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static (int, int) ExtractIntsFromStringPattern(string inputString)
        {
            // Declare new variables for our values
            int number1 = 0;
            int number2 = 0;

            // Declare / Initialize variable with regex pattern that we will use to find both numbers
            string pat = @"\d+";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Instantiate a new regex MatchCollection object to extract our matching value from the input string
            MatchCollection matches = r.Matches(inputString);

            // Declare / Initialize variables to stage our extracted values
            string first = matches[0].Value;
            string second = matches[1].Value;

            // Convert strings to ints while assigning values to our int variables
            number1 = Convert.ToInt32(first);
            number2 = Convert.ToInt32(second);

            // Return our result to the invoking caller
            return (number1, number2);
        }
    }
}
