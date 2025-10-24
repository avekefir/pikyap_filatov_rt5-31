using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Square : Rectangle, IPrint
    {
        double Length { get; }
        public Square(double length)
        {
            Length = length;
        }
        public override string ToString() => $"Квадрат со стороной {Length}\nПлощадью {GetArea()}";

        public override double GetArea() => Length * Length;
    }
}
