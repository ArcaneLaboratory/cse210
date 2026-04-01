class Program
{
    static void Main(string[] args)
    {
        HandBuilder hb = new();
        Deck d = new();
        List<Card> hand = [
            d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal()
        ];
        //hand = [new Card('d', 3), new Card('s', 3), new Card('d', 5), new Card('c', 3), new Card('d', 11), new Card('h', 3), new Card('d', 12)];
        List<Card> bestHand = [];
        foreach(Card c in hand)
        {
            Console.WriteLine(c.GetPrettyString());
        }
        Console.WriteLine("\n-----\n");
        bestHand = hb.GetBestHand(hand);
        foreach(Card c in bestHand)
        {
            Console.WriteLine(c.GetPrettyString());
        }
        // Console.WriteLine(hb.ContainsStraightFlush(hand));
        // Console.WriteLine(hb.ContainsStraight(hand));
    }
}