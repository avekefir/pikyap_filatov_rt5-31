//using MathNet.Numerics.LinearAlgebra.Complex;
using System.Collections;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var r = new Rectangle(2, 5);
            var s = new Square(3);
            var c = new Circle(5);
            var arrList = new ArrayList { r, s, c };
            arrList.Sort();
            foreach (var e in arrList)
                Console.WriteLine(e.ToString());

            var list = new List<GeometricShape> { r, s, c };
            list.Sort();
            foreach (var e in list)
                Console.WriteLine(e.ToString());

            //SparseMatrix matrix = new(5, 5);
            
        }
    }
}
