public abstract class Player
{
    private string _name;
    private (Card, Card) _hand;
    private List<ChipStack> _chips;

    public Player(string name)
    {
        
    }

    public abstract void TakeTurn();
    public abstract void Bet();
    public abstract void Call();
    public abstract void Raise();
    public abstract void Fold();
    
    
}