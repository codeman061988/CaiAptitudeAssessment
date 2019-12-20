using System;
using System.Security.Cryptography;
using System.Text;

namespace CaiAptitudeAssessment.Task3
{
    class Program
    {
        /// <summary>
        /// Main Program entry poing
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                // Display title
                Console.WriteLine("Task 3 - Encryption / Decryption o\r");
                Console.WriteLine("------------------------------\n");

                // Explain to the user what we are doing, ask the user to press enter to continue
                Console.WriteLine("For this task, we will attempt to decrypt a TripleDES Encrypted, Base64 string.");
                Console.WriteLine("Press Enter to continue...");

                // Stop and wait for the user to press enter
                Console.ReadLine();

                // Once the user presses enter, exectute the task
                string encryptedBase64 = "ABvAsOKcGXqc5uQ4O5Z53isJaH31Pa8+PeddljE4mSU=";
                string result = Decrypt(encryptedBase64);

                Console.WriteLine($"\nAlright, so the encrypted strign was {encryptedBase64}");
                Console.WriteLine($"\n\nThe decrypted result is {result}");
                Console.WriteLine("\n\nFor the solution to this problem, see the Decrypt method in Program.cs");
                Console.ReadLine();

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

        public static string Decrypt(string encryptedString)
        {
            // Declare / Initialize variables from values we know
            int keySize = 128;
            string key = "0123456789ABCDEF";
            string vecotor = "ABCDEFGH";
            string result = string.Empty;

            // Declare variable to stage key bytes
            byte[] keyBytes;

            // First lets decode the string from Base64 into a byte array
            byte[] encryptedArray = Convert.FromBase64String(encryptedString);

            // Assign byte code of the key
            keyBytes = UTF8Encoding.UTF8.GetBytes(key);

            // Instantiate new instance of TripleDESCryptoServiceProvider to help us do the work
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            // Set the key
            tdes.Key = keyBytes;

            // Out of the 4 modes which TripleDESCryptoServiceProvider class provides, lets try Electronic Code Book
            tdes.Mode = CipherMode.CBC;

            // Set padding mode, should any extra bytes be added
            tdes.Padding = PaddingMode.None;

            // Declare usable variable from member CreateDecryptor of TripleDESCryptoServiceProvider class
            ICryptoTransform cTransform = tdes.CreateDecryptor();

            // Decrypt the byte array, which has already been decoded
            byte[] resultArray = cTransform.TransformFinalBlock(encryptedArray, 0, encryptedArray.Length);

            // GC
            tdes.Clear();

            // Get the result string from the result byte array
            result = UTF8Encoding.UTF8.GetString(resultArray);

            return result;
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
