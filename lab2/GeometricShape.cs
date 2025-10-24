using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public abstract class GeometricShape
    {
        public GeometricShape() { }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public virtual double GetArea()
        {
            return 0.0;
        }
    }
}
