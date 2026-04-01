public class Card
{
    private char _suit;
    private byte _value;
    private bool _faceUp;

    public Card(char s, byte v, bool f = false)
    {
        _suit = char.ToUpper(s);
        _value = v;
        _faceUp = f;
    }

    public char GetSuit()
    {
        return _suit;
    }

    public byte GetValue()
    {
        return _value;
    }

    public void Hide()
    {
        _faceUp = false;
    }

    public void Show()
    {
        _faceUp = true;
    }

    public bool IsShown()
    {
        return _faceUp;
    }

    public string GetPrettyValue()
    {
        switch (_value)
        {
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
            case 10:
                return "Ten";
            case 11:
                return "Jack";
            case 12:
                return "Queen";
            case 13:
                return "King";
            case 14:
                return "Ace";
            default:
                return "None";
        }
    }

    public string GetPrettySuit()
    {
        switch (_suit)
        {
            case 'H':
                return "Hearts";
            case 'S':
                return "Spades";
            case 'D':
                return "Diamonds";
            case 'C':
                return "Clubs";
            default:
                return "Nones";
        }
    }

    public override string ToString()
    {
        return $"{_value}{_suit}";
    }

    public string GetPrettyString()
    {
        return $"{GetPrettyValue()} of {GetPrettySuit()}";
    }
}