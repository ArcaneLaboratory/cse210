public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration()
    {
        bool flag = true;
        while (flag)
        {
            try
            {
                _duration = int.Parse(Utils.GenericPrompt("How long, in seconds, would you like for your session?"));
                flag = false;
            }
            catch
            {
                Console.WriteLine("Please enter an integer number of seconds.");
            }
        }
        
    }

    public void DisplayIntro()
    {
        Console.WriteLine($"Welcome to the {_name} activity!\n");
        Console.WriteLine($"{_description}\n");
        SetDuration();
        Console.Clear();
        Console.WriteLine("\nGet ready...");
        Utils.Spinner();
    }

    public abstract void DisplayActivity();

    public void DisplayOutro()
    {
        Console.WriteLine($"\n\nYou have completed another {_duration} seconds of the {_name} activity. ");
        Utils.Spinner();
    }
    public void Display()
    {
        DisplayIntro();
        DisplayActivity();
        DisplayOutro();
    }

}