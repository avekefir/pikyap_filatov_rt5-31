using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public abstract class GeometricShape : IComparable, IComparable<GeometricShape>
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

        public int CompareTo(object obj)
        {
            if (obj is GeometricShape other)
                return CompareTo(other);

            throw new ArgumentException();
        }
        public int CompareTo(GeometricShape other)
        {
            if (GetArea() < other.GetArea())
                return -1;
            else if (GetArea() > other.GetArea())
                return 1;
            else
                return 0;
        }
    }
}
