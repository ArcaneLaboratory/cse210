public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing out slowly. Clear your mind and focus on your breathing."
        )
    {
        // nothing here
    }

    public override void DisplayActivity()
    {
        for (int i = 0; i < Math.Ceiling((double)_duration / 16); i++)
        {
            Console.Write($"\nBreathe in... ");
            // TODO: make this code not suck
            for (int j = 1; j < 5; j++)
            {
                Console.Write($"{j}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.Write("Hold... ");
            for (int j = 1; j < 5; j++)
            {
                Console.Write($"{j}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.Write("\nBreathe out... ");
            for (int j = 1; j < 5; j++)
            {
                Console.Write($"{j}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.Write("Hold... ");
            for (int j = 1; j < 5; j++)
            {
                Console.Write($"{j}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        Console.Clear();
    }
}
