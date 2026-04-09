public class BotPlayer : Player
{
    private List<string> _strategy;

    public BotPlayer(string name, List<string> strategy) : base(name)
    {
        _strategy = strategy;
    }
    public override int[] TakeTurn(int maxCurrentBet, int myCurrentBet)
    {
        Console.WriteLine($"{GetName()} calls.");
        return [2, maxCurrentBet-myCurrentBet]; // TODO: implement bot strategies
    }
}