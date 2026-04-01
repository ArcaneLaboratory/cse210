public class BotPlayer : Player
{
    private List<string> _strategy;

    public BotPlayer(string name, List<string> strategy) : base(name)
    {
        _strategy = strategy;
    }
    public override void TakeTurn(){}
    public override void Bet(){}
    public override void Call(){}
    public override void Check(){}
    public override void Raise(){}
    public override void Fold(){}
}