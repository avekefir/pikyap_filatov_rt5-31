using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace labs
{
    public class lab1
    {
        public static void Lab1(string[] args)
        {
            double a, b, c; //ax*x=bx=c=0
            double[] result;
            if (args.Length == 3)
            {
                result = SolveEquation(double.Parse(args[0]), double.Parse(args[1]), double.Parse(args[2]));
                PrintResult(result);
            }
            else
            {
                bool isValidA, isValidB, isValidC;
                do
                {
                    Console.WriteLine("Введите корректные коэффициенты:");
                    Console.Write("A:");
                    isValidA = DoubleTryParseUniversal(Console.ReadLine(), out a);
                    Console.Write("B:");
                    isValidB = DoubleTryParseUniversal(Console.ReadLine(), out b);
                    Console.Write("C:");
                    isValidC = DoubleTryParseUniversal(Console.ReadLine(), out c);
                } while (!(isValidA && isValidB && isValidC));
                result = SolveEquation(a, b, c);
                PrintResult(result);
            }
        }
        public static bool DoubleTryParseUniversal(string? input, out double result) // 0,5 0.5
        {
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out result)) // comma
                return true;
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result)) // point
                return true;
            result = 0;
            return false;
        }
        public static double[] SolveEquation(double a, double b, double c) //╚║
        {
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
                return [];
            else if (discriminant == 0)
                return [-b / 2 * a];
            else
                return [
                    (-b + Math.Sqrt(discriminant)) / 2 * a,
                    (-b - Math.Sqrt(discriminant)) / 2 * a
                ];
        }
        public static void PrintResult(double[] result)
        {
            var origColor = Console.ForegroundColor;
            if (result.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет");
                Console.ForegroundColor = origColor;
            }
            else if(result.Length == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Корень выражения");
                Console.WriteLine($"1: {result[0]}");
                Console.ForegroundColor = origColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Корни выражения");
                Console.WriteLine($"1: {result[0]}\n2: {result[1]}");
                Console.ForegroundColor = origColor;
            }
        }
    }
}
