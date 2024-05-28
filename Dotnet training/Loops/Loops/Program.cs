namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter The Secind number = ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                int addition = num1 + num2;
                int substract = num1 - num2;
                int multiplication = num1 * num2;
                int division = num1 / num2;
                int mod = num1 % num2;
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
        }

    }
}