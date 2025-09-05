using System;

namespace OOP_Concepts
{
    // Abstraction: Base class defines a common contract
    public abstract class Shape
    {
        public string Color { get; set; }

        // Abstract method must be overridden
        public abstract double CalculateArea();

        // Virtual method can be overridden
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Shape Color: {Color}");
        }
    }

    // Inheritance + Polymorphism
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius, string color)
        {
            Radius = radius;
            Color = color;
        }

        public override double CalculateArea() => Math.PI * Radius * Radius;

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Circle Radius: {Radius}, Area: {CalculateArea()}");
        }
    }

    // Inheritance + Polymorphism
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height, string color)
        {
            Width = width;
            Height = height;
            Color = color;
        }

        public override double CalculateArea() => Width * Height;

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Rectangle {Width}x{Height}, Area: {CalculateArea()}");
        }
    }
}
