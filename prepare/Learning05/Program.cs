class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [new Circle("red", 5.0), new Rectangle("blue", 4.5, 8.0), new Square("green", 3.3)];
        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()}, {shape.GetArea()}");
        }
    }
}