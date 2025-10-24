using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Circle : GeometricShape
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
