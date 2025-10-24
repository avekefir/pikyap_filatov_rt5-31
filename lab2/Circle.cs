using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Circle : GeometricShape, IPrint
    {
        double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override string ToString()
        {
            return $"Круг радиусом {Radius}\nПлощадью {GetArea()}";
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

    }
}
