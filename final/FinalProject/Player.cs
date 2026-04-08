public abstract class Player
{
    protected string _name;
    protected List<Card> _hand;
    protected int _chips;

    public Player(string name)
    {
        _name = name;
        _hand = [];
        _chips = 50000;
    }
    
    // these might end up being something other than void. not sure yet.
    public void AcceptCard(Card c)
    {
        _hand.Add(c);
    }
    public List<Card> GetHand()
    {
        return _hand;
    }
    public string GetName()
    {
        return _name;
    }
    // TakeTurn returns an array where the first element is the id of the action and the second is the amount of the bet (0 if no increase, -1 if fold)
    // 1 for fold, 2 for check or call, 3 for raise or bet
    public abstract int[] TakeTurn(int maxCurrentBet, int myCurrentBet);
    public void ShowHand()
    {
        foreach(Card c in _hand)
        {
            Console.WriteLine(c.GetPrettyString());
        }
    }
    public int Pay(int amount)
    {
        _chips -= amount;
        return amount;
    }
}