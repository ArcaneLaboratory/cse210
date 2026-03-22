public class Program
{
    static void Main(string[] args)
    {
        using StreamWriter file = new("example.txt");
        for(int i = 0; i < 10000000; i++)
        {
            file.Write("0");
        }
        file.Close();
    }
}