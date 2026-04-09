public class RankedHand
{
    public List<Card> _hand;
    public int _rank;

    public RankedHand(List<Card> hand, int rank)
    {
        _hand = hand;
        _rank = rank;
    }

    public RankedHand()
    {
        _hand = [];
        _rank = 0;
    }
    public void DisplayHand()
    {
        HandBuilder.SortHand(_hand);
        foreach(Card c in _hand)
        {
            Console.Write($"{c.GetPrettyString()} ");
        }
        int rank1 = int.Log2(_rank / 200000);
        switch (rank1)
        {
            case 1:
                Console.WriteLine("Pair");
                break;
            case 2:
                Console.WriteLine("Two Pair");
                break;
            case 3:
                Console.WriteLine("Trips");
                break;
            case 4:
                Console.WriteLine("Straight");
                break;
            case 5:
                Console.WriteLine("Flush");
                break;
            case 6:
                Console.WriteLine("Full House");
                break;
            case 7:
                Console.WriteLine("Quads");
                break;
            case 8:
                Console.WriteLine("Straight Flush");
                break;
            default:
                Console.WriteLine("High Card");
                break;
        }

    }
}
