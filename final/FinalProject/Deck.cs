public class Deck
{
    public List<Card> _cards;
    private Random shuffler = new();

    public Deck()
    {
        _cards = [];
        byte value;
        char suit = ' ';
        for (byte i = 0; i < 52; i++)
        {
            switch (i % 4)
            {
                case 0:
                    suit = 'H';
                    break;
                case 1:
                    suit = 'S';
                    break;
                case 2:
                    suit = 'D';
                    break;
                case 3:
                    suit = 'C';
                    break;
            }
            value = (byte)(i % 13);
            value += 2;
            _cards.Add(new Card(suit, value));
        }
        Shuffle();
    }

    // Shuffle code adapted from grenade, https://stackoverflow.com/a/1262619

    public void Shuffle()
    {
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = shuffler.Next(n + 1);
            (_cards[n], _cards[k]) = (_cards[k], _cards[n]);
        }
    }

    // In Texas hold 'em, the deck is shuffled after each hand, therefore dealing need not account for the deck running out of cards.  

    public Card Deal()
    {
        Card C = _cards[0];
        _cards.Remove(C);
        return C;
    }
}
