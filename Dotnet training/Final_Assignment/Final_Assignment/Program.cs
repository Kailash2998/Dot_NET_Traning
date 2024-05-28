using System;

namespace Final_Assignment
{
    // Base class Script
    class Script
    {
        // Property for the name of the script
        public string Name { get; set; }
        public Script(string name)
        {
            Name = name;
        }
        public virtual int AlphabetCount(string script)
        {
            throw new NotImplementedException("Alphabet Count method not implemented in the base class.");
        }
    }
    // Derived class Devanagari implement the Base class Script
    class Devanagari : Script
    {        public Devanagari() : base("Devanagari") { }
        public override int AlphabetCount(string script)
        {
            int count = 0;
            foreach (char c in script)
            {
                if ((int)c >= 0x0900 && (int)c <= 0x097F)
                {
                    count++;
                }
            }
            return count;
        }
    }

    // Derived class Latin implement the Base class Script
    class Latin : Script
    {
        public Latin() : base("Latin") { }
        public override int AlphabetCount(string script)
        {
            int count = 0;
            foreach (char c in script)
            {
                if (((int)c >= 0x0041 && (int)c <= 0x005A) || ((int)c >= 0x0061 && (int)c <= 0x007A))
                {
                    count++;
                }
            }

            return count;
        }
    }

    class Program
    {
       public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Choose a language:");
                Console.WriteLine("1. Devanagari");
                Console.WriteLine("2. Latin");
                Console.Write("Enter your choice (1 or 2): ");
                int choice = int.Parse(Console.ReadLine());

                Script script;

                switch (choice)
                {
                    case 1:
                        script = new Devanagari();
                        break;
                    case 2:
                        script = new Latin();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }
                Console.Write("Enter the script: ");
                string userScript = Console.ReadLine();
                Console.WriteLine($"Number of alphabets in the script: {script.AlphabetCount(userScript)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
