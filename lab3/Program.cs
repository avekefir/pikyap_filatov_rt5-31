//using MathNet.Numerics.LinearAlgebra.Complex;
using System.Collections;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(2, 5);
            var sq = new Square(3);
            var circ = new Circle(5);
            var arrList = new ArrayList { rect, sq, circ };
            arrList.Sort();
            foreach (var e in arrList)
                Console.WriteLine(e.ToString());

            var list = new List<GeometricShape> { rect, sq, circ };
            list.Sort();
            foreach (var e in list)
                Console.WriteLine(e.ToString());
        }
    }
}
