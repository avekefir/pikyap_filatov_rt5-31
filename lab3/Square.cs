using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Square : Rectangle
    {
        double Length { get; }
        public Square(double length)
        {
            Length = length;
        }
        public override string ToString()
        {
            return $"Квадрат со стороной {Length}\nПлощадью {GetArea()}";
        }
        public override double GetArea()
        {
            return Length * Length;
        }
    }
}
