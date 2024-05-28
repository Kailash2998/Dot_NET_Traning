using System;

namespace Assignment1
{
    public  class Loop
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //Q.1 Write a C# program to demonstrate the use of loops for , do- while and while,switch statements
            ///for loop 
            Console.WriteLine("Start For loop here");
            Console.WriteLine("Enter Your Number");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(number + " X " + i + " = " + number * i);
            }

            ///Do and while loop
            Console.WriteLine("\nDo and While Loop Start here");
            string confirm;
            do
            {
                Console.Write("Enter The First Number = ");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter The Secind number = ");
                int number2 = Convert.ToInt32(Console.ReadLine());

                int addition = number1 + number2;
                int substract = number1 - number2;
                int multiplication = number1 * number2;
                int division = number1 / number2;
                int mod = number1 % number2;
                Console.WriteLine(" Addition of The number Is = " + addition);
                Console.WriteLine(" Substraction of The number Is = " + substract);
                Console.WriteLine(" Multplication of The number Is = " + multiplication);
                Console.WriteLine(" Division of The number Is = " + division);
                Console.WriteLine(" Modulus of The number Is = " + mod);

                Console.Write("Do you want to repeat your do-while loop program? yes/no: ");
                confirm = Console.ReadLine();
            }
            while (confirm == "yes");
            Console.WriteLine("Out of the loop");

            // while loop example
            Console.WriteLine("while loop example \n");
            int initialValue = 2;
            int multiplyBy = 3;
            int limit = 100;
            int result = initialValue;
            Console.WriteLine("Multiplication process:");

            // Perform the multiplication process in a loop.
            while (result <= limit)
            {
                Console.WriteLine(result + " * " + multiplyBy + " = " + (result * multiplyBy));
                result *= multiplyBy;
            }

            //Switch Statement
            Console.WriteLine("\nStart Switch Case");
            Console.Write("Enter a number between 1 and 3: ");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.WriteLine("You entered One.");
                    break;
                case 2:
                    Console.WriteLine("You entered Two.");
                    break;
                case 3:
                    Console.WriteLine("You entered Three.");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

            // Q.2 C# program to demonstrate the use of implicit typed local variables.
            //implicit typed conversion
            //Declear the Variables with var as implicit typed local 'var'
            var integer = 10;
            var pi = 3.147;
            var name = "This is my Assignment Number One ";
            var isTrue = true;
            Console.WriteLine("\nImplicit Type Conversion Started");

            // Display the inferred types and values
            Console.WriteLine($"integer is of type: {integer.GetType()}, value: {integer}");
            Console.WriteLine($"name is of type: {name.GetType()}, value: {name}");
            Console.WriteLine($"isTrue is of type: {isTrue.GetType()}, value: {isTrue}");
            Console.WriteLine($"pi is of type: {pi.GetType()}, value: {pi}");

            //Q.3 C# program to demonstrate the use of Value Type and Reference Type.

            // Value Type Example: int
            Console.WriteLine("\nValue Type Example: int ");
            int valueNum1 = 10;
            int valueNum2 = valueNum1;

            Console.WriteLine("Value Type Example:");
            Console.WriteLine("Original valueNum1: " + valueNum1);
            Console.WriteLine("Copied valueNum2: " + valueNum2);

            valueNum1 = 20; // Modify valueNum1
            Console.WriteLine("Modified valueNum1: " + valueNum1);
            Console.WriteLine("Copied value number 2 remains unchanged: " + valueNum2);
            Console.ReadLine();

            // Reference Type Example: Array
            Console.WriteLine("\nReference Type Example: Array \n");
            int[] referenceArray1 = { 1, 2, 3, 4, 5, 6, 7, };
            int[] referenceArray2 = referenceArray1;

            Console.WriteLine("Reference Type Example:");
            Console.WriteLine("Original referenceArray1: [" + string.Join(", ", referenceArray1) + "]");
            Console.WriteLine("Copied referenceArray2: [" + string.Join(", ", referenceArray2) + "]");

            referenceArray1[0] = 9; // Modify referenceArray1
            Console.WriteLine("Modified referenceArray1: [" + string.Join(", ", referenceArray1) + "]");
            Console.WriteLine("Copied reference array 2 is also modified: [" + string.Join(", ", referenceArray2) + "]");
            Console.ReadLine();

            // interface class example
            Console.WriteLine("\nInterface Class Example \n");
            IShape circle = new Circle(5.0);
            IShape rectangle = new Rectangle(4.0, 6.0);

            Console.WriteLine("Using the IShape interface:");
            Console.WriteLine("Area of Circle: " + circle.CalculateArea() + ", Perimeter of Circle: " + circle.CalculatePerimeter());
            Console.WriteLine("Area of Rectangle: " + rectangle.CalculateArea() + ", Perimeter of Rectangle: " + rectangle.CalculatePerimeter());

            Console.ReadLine();

            // partial class example
            Console.WriteLine("\nPartial Class Example \n");
            Employee employee = new Employee();
            employee.name = "Sahil";
            employee.age = 20;
            employee.salary = 100000;
            employee.phoneNumber = "8531642536";

            Console.WriteLine($"Employee name is - {employee.name}");
            Console.WriteLine($"Employee age is - {employee.age}");
            Console.WriteLine($"Employee salary is - {employee.salary}");
            Console.WriteLine($"Employee phoneNumber is - {employee.phoneNumber}");
            Console.ReadLine();

            // static class example
            Console.WriteLine("\nStatic Class Example \n");
            double num1 = 10.5;
            double num2 = 5.2;

            Console.WriteLine($"Addition: {num1} + {num2} = {MathUtility.Add(num1, num2)}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {MathUtility.Subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {MathUtility.Multiply(num1, num2)}");
            Console.WriteLine($"Division: {num1} / {num2} = {MathUtility.Divide(num1, num2)}");

            Console.ReadLine();
        }
    }

    // Interface Example
    // Define an interface for shapes
    interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    // Implement the interface in circle and rectangle classes
    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double CalculateArea()
        {
            return width * height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (width + height);
        }
    }

    // Partial class example
    partial class Employee
    {
        public string name;
        public int age;
    }

    partial class Employee
    {
        public double salary;
        public string phoneNumber;
    }

    // Static class example
    public static class MathUtility
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b != 0)
            {
                return a / b;
            }
            else
            {
                Console.WriteLine("Division by zero is not allowed.");
                return double.NaN;
            }
        }
    }
}