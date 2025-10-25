using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Rectangle : GeometricShape
    {
        double Length { get; }
        double Width { get; }
        public Rectangle() { }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override string ToString() => $"Прямоугольник со сторонами {Length} и {Width}\nПлощадью {GetArea()}";

        public override double GetArea() => Length * Width;        
    }
}
