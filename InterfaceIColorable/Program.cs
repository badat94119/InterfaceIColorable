using System;

namespace InterfaceIColorable
{
    public interface IColorable
    {
        void HowToColor();
    }

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle, IColorable
    {
        public Square(double side) : base(side, side)
        {
        }

        public void HowToColor()
        {
            Console.WriteLine("Color all four sides.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = { new Circle(3), new Rectangle(2, 4), new Square(5) };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Area of shape: {shape.Area()}");

                if (shape is IColorable)
                {
                    ((IColorable)shape).HowToColor();
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
