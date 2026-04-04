public class Game
{
    private List<Player> _players;
    private List<ChipStack> _pot;
    private Deck _deck;
    private HandBuilder _builder;
    private List<Card> _table;

    public Game(List<Player> players)
    {
        _players = players;
        _pot = [];
        _deck = new Deck();
        _builder = new HandBuilder();
        _table = [];
    }

    
}