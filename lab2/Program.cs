namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(4, 5);
            var circle = new Circle(1);
            var square = new Square(10);
            rectangle.Print();
            circle.Print();
            square.Print();
        }
    }
}
