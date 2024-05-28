using System;

public class Script
{
    protected string Text { get; set; }

    public Script(string text)
    {
        Text = text;
    }

    public virtual int AlphabetCount()
    {
        try
        {
            int count = 0;
            foreach (char c in Text)
            {
                if (char.IsLetter(c))
                {
                    count++;
                }
            }
            return count;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return -1;
        }
    }
}

public class Devanagari : Script
{
    public Devanagari(string text) : base(text)
    {
    }
    /// <summary>
    /// Counting the Alpha bets
    /// </summary>
    /// <returns></returns>
    public override int AlphabetCount()
    {
        try
        {
            int count = 0;
            foreach (char c in Text)
            {
                if (char.IsLetter(c))
                    count++;
            }
            return count;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return -1;
        }
    }
}

public class Latin : Script
{
    public Latin(string text) : base(text)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select the script type:");
            Console.WriteLine("1. Devanagari");
            Console.WriteLine("2. Latin");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Enter Devanagari text: ");
                        string devanagariText = Console.ReadLine();
                        if (!IsValidInput(devanagariText))
                        {
                            throw new Exception("Invalid input. Please enter alphabetic characters only.");
                        }
                        Devanagari devanagariScript = new Devanagari(devanagariText);
                        Console.WriteLine($"Devanagari Script - Alphabet Count: {devanagariScript.AlphabetCount()}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        Console.Write("Enter Latin text: ");
                        string latinText = Console.ReadLine();
                        if (!IsValidInput(latinText))
                        {
                            throw new Exception("Invalid input. Please enter alphabetic characters only.");
                        }
                        Latin latinScript = new Latin(latinText);
                        Console.WriteLine($"Latin Script - Alphabet Count: {latinScript.AlphabetCount()}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    static bool IsValidInput(string text)
    {
        foreach (char c in text)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }
}
