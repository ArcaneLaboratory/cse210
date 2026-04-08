class Program
{
    static void Main(string[] args)
    {
        Game game = new([new HumanPlayer("User"), new BotPlayer("Caller 1", ["lorem"])]);
        game.PlayRound();
    }
    static void Tests()
    {
        
        // HandBuilder hb = new();
        // Deck d = new();
        // List<Card> hand1 = [
        //     d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal()
        // ];
        // List<Card> hand2 = [
        //     d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal(), d.Deal()
        // ];
        // //hand = [new Card('d', 3), new Card('s', 3), new Card('d', 5), new Card('c', 3), new Card('d', 11), new Card('h', 3), new Card('d', 12)];
        // RankedHand bestHand1;
        // RankedHand bestHand2;
        // foreach(Card c in hand1)
        // {
        //     Console.WriteLine(c.GetPrettyString());
        // }
        // Console.WriteLine("\n-----\n");
        // bestHand1 = hb.GetBestHand(hand1);
        // foreach(Card c in bestHand1._hand)
        // {
        //     Console.WriteLine(c.GetPrettyString());
        // }
        // Console.WriteLine("\n-----\n");
        // // Console.WriteLine(hb.ContainsStraightFlush(hand));
        // // Console.WriteLine(hb.ContainsStraight(hand));
        // foreach(Card c in hand2)
        // {
        //     Console.WriteLine(c.GetPrettyString());
        // }
        // Console.WriteLine("\n-----\n");
        // bestHand2 = hb.GetBestHand(hand2);
        // foreach(Card c in bestHand2._hand)
        // {
        //     Console.WriteLine(c.GetPrettyString());
        // }
        // Console.WriteLine("\n-----\n");
        // Console.WriteLine(bestHand1._rank > bestHand2._rank);
    }
}