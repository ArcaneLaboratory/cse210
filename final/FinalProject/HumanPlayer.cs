public class HumanPlayer : Player
{
    public HumanPlayer(string name) : base(name)
    {
        
    }
    public override int[] TakeTurn(int maxCurrentBet, int myCurrentBet)
    {
        int[] output = [0, 0];
        while (true)
        {
            Console.WriteLine("Enter a number:\n\t1. Fold\n\t2. Check/Call\n\t3. Bet/Raise");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You fold.");
                        return [1, -1];
                    case 2:
                        if (myCurrentBet == maxCurrentBet)
                        {
                            Console.WriteLine("You check.");                            
                            return [2, 0];
                        }
                        else
                        {
                            Console.WriteLine($"You call. (from {myCurrentBet} to {maxCurrentBet})"); 
                            return [2, maxCurrentBet-myCurrentBet];
                        }
                    case 3:
                        try
                        {
                            Console.WriteLine($"How much to raise by? (Will raise that much over the current bet of {maxCurrentBet}. Your current bet is {myCurrentBet}.)");
                            int raiseAmount = int.Parse(Console.ReadLine());
                            Console.WriteLine($"You raise by {raiseAmount} to {maxCurrentBet+raiseAmount}");
                            return [3, maxCurrentBet + raiseAmount - myCurrentBet];
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a valid integer amount to raise by.");
                            continue;
                        }
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid option from the menu.\n");
                continue;
            }
            
        }
        
    }   
}