using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Radius must be a positive number");
        }
        return Math.PI * radius * radius;
    }
}

class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("Width and height must be positive numbers");
        }
        return width * height;
    }
}

class Triangle : Shape
{
    private double baseLength;
    private double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double CalculateArea()
    {
        if (baseLength <= 0 || height <= 0)
        {
            throw new ArgumentException("Base and height must be positive numbers");
        }
        return 0.5 * baseLength * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Choose a shape to calculate area:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("3. Square");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter radius of circle:");
                    double circleRadius = double.Parse(Console.ReadLine());
                    Circle circle = new Circle(circleRadius);
                    Console.WriteLine("Circle Area: " + circle.CalculateArea());
                    break;
                case 2:
                    Console.WriteLine("Enter width of rectangle:");
                    double rectWidth = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter height of rectangle:");
                    double rectHeight = double.Parse(Console.ReadLine());
                    Rectangle rectangle = new Rectangle(rectWidth, rectHeight);
                    Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
                    break;
                case 3:
                    Console.WriteLine("Enter base length of triangle:");
                    double triBase = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter height of triangle:");
                    double triHeight = double.Parse(Console.ReadLine());
                    Triangle triangle = new Triangle(triBase, triHeight);
                    Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
