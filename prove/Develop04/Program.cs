using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        Activity a;
        while (running)
        {
            try
            {
                int choice = int.Parse(
                    Utils.GenericPrompt(
                        "Menu options:\n\t1. Start breathing activity\n\t2. Start reflection activity\n\t3. Start listing activity\n\t4. Quit"
                    )
                );
                switch (choice)
                {
                    case 1:
                        a = new BreathingActivity();
                        a.Display();
                        break;
                    case 2:
                        a = new ReflectionActivity();
                        a.Display();
                        break;
                    case 3:
                        a = new ListingActivity();
                        a.Display();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid menu option.");
            }
        }
    }
}
