using System;
using System.IO;

namespace Assignment_3
{
    // Define a delegate.
    public delegate void Calculation(int num1, int num2);
    internal class Program
    {
        // Create methods that match the delegate's signature.
        /// <summary>
        /// Additiona of two numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public static void Addition(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine("Addition result is: {0} ", result);
        }
        public static void Subtraction(int num1, int num2)
        {
            int result = num1 - num2;
            Console.WriteLine("Subtraction result is: {0} ", result);
        }
        public static void Multiplication(int num1, int num2)
        {
            int result = num1 * num2;
            Console.WriteLine("Multiplication result is: {0} ", result);
        }
        public static void Division(int num1, int num2)
        {
            int result = num1 / num2;
            Console.WriteLine("Division result is: {0} ", result);
        }

        // C# program that demonstrates how to create and use a Func delegate. 
        // Define a method that takes two integers and returns their sum.
        static int Add(int a, int b)
        {
            return a + b;
        }

        // Define a method that takes a string and returns its length
        public static int StringLength(string input)
        {
            return input.Length;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Example of Delegate.\n");
            // Instantiate the delegate.
            Calculation calculation = new Calculation(Program.Addition);
            // Invoke the delegate.
            calculation.Invoke(10, 5);

            calculation = Subtraction;
            calculation(10, 5);

            calculation = Multiplication;
            calculation(10, 5);

            calculation = Division;
            calculation(10, 5);

            // Create a Func delegate with the specified parameter types and return type.
            Console.WriteLine("\nExample of func type Delegate.\n");
            Func<int, int, int> addFunc = Add;
            Func<string, int> lengthFunc = StringLength;

            // Use the Func delegate to call methods.
            int result1 = addFunc(5, 3);
            int result2 = lengthFunc("Hello, World!");

            Console.WriteLine("Sum of numbers is : " + result1);
            Console.WriteLine("String Length is : " + result2);

            // Program to read file using stream reader.
            Console.WriteLine("\nExample of File stram reader.\n");
            string filePath = @"D:\newData.txt"; // Specify the path to your text file.

            // Check if the file exists.
            if (File.Exists(filePath))
            {
                // Create a StreamReader to read the file.
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    // Read and display each line from the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
            }

            // A Program to append text to file           
            string textToAppend = "This is the new line to be appended.";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                // Append the text to the file
                writer.WriteLine(textToAppend);
            }

            Console.WriteLine("\nText has been appended to the file.");

            // A Program to delete file.
            string newFilePath = @"D:\newData.txt"; // Specify the path to the file you want to delete

            // Check if the file exists before attempting to delete it
            if (File.Exists(newFilePath))
            {
                // Delete the file
               /* File.Delete(newFilePath);
                Console.WriteLine("File deleted successfully.");*/
            }
            else
            {
                Console.WriteLine("File does not exist. Cannot delete.");
            }

            Console.ReadLine();
        }
    }
}

