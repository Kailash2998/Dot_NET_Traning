namespace Implicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declear the Variables with var as implicit typed local 
            var i = 10;
            var pi = 3.147;
            var name = "This is my Assignment Number One ";
            var isTrue = true;

            // Console.WriteLine(i);
            Console.WriteLine($"i is of type: {i.GetType()}, value: {i}");
            Console.WriteLine($"name is of type: {name.GetType()}, value: {name}");
            Console.WriteLine($"isTrue is of type: {isTrue.GetType()}, value: {isTrue}");
            Console.WriteLine($"pi is of type: {pi.GetType()}, value: {pi}");
        }
    }
}
