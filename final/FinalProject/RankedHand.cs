public struct RankedHand
{
    public List<Card> _hand;
    public int _rank;

    public RankedHand(List<Card> hand, int rank)
    {
        _hand = hand;
        _rank = rank;
    }
}
