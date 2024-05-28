using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment2
{
    // Define a generic class
    class GenericClass<T>
    {
        private T value;

        public GenericClass(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
    }

    // Custom exception class that inherits from Exception
    class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Single-Dimensional Array
            int[] singleDimensionalArray = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Single-Dimensional Array:");
            foreach (int num in singleDimensionalArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

            // Multi-Dimensional Array
            int[,] multiDimensionalArray = new int[2, 3]
            {
                {1, 2, 3},
                {4, 5, 6}
            };
            Console.WriteLine("Multi-Dimensional Array:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(multiDimensionalArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Jagged Array
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };
            Console.WriteLine("Jagged Array:");
            foreach (int[] row in jaggedArray)
            {
                foreach (int num in row)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Create an instance of GenericClass with int type
            GenericClass<int> intGenericClass = new GenericClass<int>(42);
            int intValue = intGenericClass.GetValue();
            Console.WriteLine("GenericClass with int: " + intValue);

            // Create an instance of GenericClass with string type
            GenericClass<string> stringGenericClass = new GenericClass<string>("Hello, Generics!");
            string stringValue = stringGenericClass.GetValue();
            Console.WriteLine("GenericClass with string: " + stringValue);

            // Create an instance of GenericClass with double type
            GenericClass<double> doubleGenericClass = new GenericClass<double>(3.14);
            double doubleValue = doubleGenericClass.GetValue();
            Console.WriteLine("GenericClass with double: " + doubleValue);

            Console.WriteLine();

            // Create an ArrayList
            ArrayList arrayList = new ArrayList();

            // Add elements to the ArrayList
            arrayList.Add(42);
            arrayList.Add("Hello");
            arrayList.Add(3.14);
            arrayList.Add(true);

            // Display the elements in the ArrayList
            Console.WriteLine("Elements in the ArrayList:");

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // Remove an element from the ArrayList
            arrayList.Remove("Hello");

            // Display the modified ArrayList
            Console.WriteLine("\nArrayList after removing 'Hello':");

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Create a SortedList
            SortedList sortedList = new SortedList();

            // Add elements to the SortedList
            sortedList.Add(3, "C");
            sortedList.Add(1, "A");
            sortedList.Add(2, "B");

            // Display the elements in the SortedList
            Console.WriteLine("Elements in the SortedList:");

            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // Access elements by key
            int keyToFind = 2;
            if (sortedList.ContainsKey(keyToFind))
            {
                Console.WriteLine($"\nValue for key {keyToFind}: {sortedList[keyToFind]}");
            }

            // Remove an element by key
            int keyToRemove = 1;
            sortedList.Remove(keyToRemove);

            // Display the modified SortedList
            Console.WriteLine("\nSortedList after removing key 1:");

            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
            Console.WriteLine();

            // Create a Dictionary with string keys and int values
            Dictionary<string, int> employeeSalaries = new Dictionary<string, int>();

            // Add employees and their salaries to the Dictionary
            employeeSalaries.Add("Hriteek", 50000);
            employeeSalaries.Add("Farahan", 60000);
            employeeSalaries.Add("Rajesh", 75000);

            // Access and display the salaries of employees
            Console.WriteLine("Employee Salaries:");
            Console.WriteLine("Hriteek's Salary: " + employeeSalaries["Hriteek"]);
            Console.WriteLine("Farahan's Salary: " + employeeSalaries["Farahan"]);
            Console.WriteLine("Rajesh's Salary: " + employeeSalaries["Rajesh"]);

            // Check if a key exists in the Dictionary
            string employeeToFind = "Hriteek";
            if (employeeSalaries.ContainsKey(employeeToFind))
            {
                Console.WriteLine($"{employeeToFind}'s Salary: " + employeeSalaries[employeeToFind]);
            }
            else
            {
                Console.WriteLine($"{employeeToFind} not found in the Dictionary.");
            }

            // Iterate through the Dictionary to access all key-value pairs
            Console.WriteLine("\nAll Employee Salaries:");
            foreach (var entry in employeeSalaries)
            {
                Console.WriteLine($"{entry.Key}'s Salary: {entry.Value}");
            }
            Console.WriteLine();

            // Create a Hashtable with string keys and string values
            Hashtable countries = new Hashtable();

            // Add countries and their capitals to the Hashtable
            countries["India"] = "New Delhi";
            countries["Canada"] = "Ottawa";
            countries["UK"] = "London";
            countries["France"] = "Paris";

            // Access and display the capitals of countries
            Console.WriteLine("Country Capitals:");
            Console.WriteLine("Capital of India: " + countries["India"]);
            Console.WriteLine("Capital of Canada: " + countries["Canada"]);
            Console.WriteLine("Capital of UK: " + countries["UK"]);
            Console.WriteLine("Capital of France: " + countries["France"]);

            // Check if a key exists in the Hashtable
            string countryToFind = "Germany";
            if (countries.Contains(countryToFind))
            {
                Console.WriteLine($"Capital of {countryToFind}: " + countries[countryToFind]);
            }
            else
            {
                Console.WriteLine($"{countryToFind} not found in the Hashtable.");
            }

            // Remove a key-value pair from the Hashtable
            countries.Remove("UK");
            Console.WriteLine("\nCountry Capitals after removing UK:");
            foreach (DictionaryEntry entry in countries)
            {
                Console.WriteLine($"Capital of {entry.Key}: {entry.Value}");
            }
            Console.WriteLine();

            // Create a Stack to store integers
            Stack numberStack = new Stack();

            // Push (add) elements onto the stack
            numberStack.Push(10);
            numberStack.Push(20);
            numberStack.Push(30);
            numberStack.Push(40);
            numberStack.Push(50);

            // Display the elements in the stack
            Console.WriteLine("Stack Elements:");
            foreach (var number in numberStack)
            {
                Console.WriteLine(number);
            }

            // Peek at the top element without removing it
            int topElement = (int)numberStack.Peek();
            Console.WriteLine("\nTop element (Peek): " + topElement);

            // Pop (remove) elements from the stack and display them
            Console.WriteLine("\nPopped Elements:");
            while (numberStack.Count > 0)
            {
                int poppedElement = (int)numberStack.Pop();
                Console.WriteLine(poppedElement);
            }
            Console.WriteLine();

            // Create a Queue to store strings
            Queue stringQueue = new Queue();

            // Enqueue (add) elements to the queue
            stringQueue.Enqueue("Raghav");
            stringQueue.Enqueue("Sahil");
            stringQueue.Enqueue("Shubham");
            stringQueue.Enqueue("Ritesh");
            stringQueue.Enqueue("Rahul");

            // Display the elements in the queue
            Console.WriteLine("Queue Elements:");
            foreach (var name in stringQueue)
            {
                Console.WriteLine(name);
            }

            // Dequeue (remove) elements from the queue and display them
            Console.WriteLine("\nDequeued Elements:");
            while (stringQueue.Count > 0)
            {
                string dequeuedElement = (string)stringQueue.Dequeue();
                Console.WriteLine(dequeuedElement);
            }
            Console.WriteLine();

            // Create a tuple to represent a person's information
            Tuple<string, int, double> person = new Tuple<string, int, double>("Raghav", 25, 5.7);

            // Access and display the values in the tuple
            Console.WriteLine($"Name: {person.Item1}");
            Console.WriteLine($"Age: {person.Item2}");
            Console.WriteLine($"Height: {person.Item3} feet");

            var personWithNames = (Name: "Roshan", Age: 30, Height: 6.0);
            Console.WriteLine($"Name: {personWithNames.Name}");
            Console.WriteLine($"Age: {personWithNames.Age}");
            Console.WriteLine($"Height: {personWithNames.Height} feet");
            Console.WriteLine();

            // Exception Handling Implementation.
            try
            {
                // Prompt the user to enter two numbers
                Console.Write("Enter the first number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                int num2 = int.Parse(Console.ReadLine());

                // Perform division
                double result = DivideNumbers(num1, num2);

                // Display the result
                Console.WriteLine($"Result of division: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid input. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Program execution completed.");
            }
            Console.WriteLine();

            // 'throw' keyword is used to throw and catch custom exceptions.
            Console.WriteLine("'throw' keyword is used to throw and catch custom exceptions : ");
            try
            {
                Console.WriteLine("Enter a number:");

                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new CustomException("Negative numbers are not allowed.");
                }

                Console.WriteLine($"You entered a valid number: {number}");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Custom Exception: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Exception: {ex.Message}. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
        static int DivideNumbers(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }
            return num1 / num2;
        }
    }
}
