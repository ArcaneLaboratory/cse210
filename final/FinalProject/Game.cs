public class Game
{
    private List<Player> _players;
    private int _pot;
    private Deck _deck;
    private HandBuilder _builder;
    private List<Card> _table;
    private List<Card> _burn;
    private int _startingPlayer;
    private int _minRaise = 100;
    private int _maxCurrentBet;
    private int[] _currentBets;

    public Game(List<Player> players)
    {
        _players = players;
        _currentBets = new int[players.Count];
        Array.Fill(_currentBets, 0);
        _deck = new Deck();
        _builder = new HandBuilder();
        _table = [];
        _burn = [];
        _startingPlayer = 0;
    }

    public void PlayRound()
    {
        InitialDeal();
        Betting();
        Flop();
        Betting();
        Turn();
        Betting();
        River();
        Betting();
        EndRound();
    }

    private void InitialDeal()
    {
        for(int i = _startingPlayer; i < (_startingPlayer+_players.Count)*2; i++)
        {
            _players[i%_players.Count].AcceptCard(_deck.Deal());
        }
        foreach(Player p in _players)
        {
            if(p is HumanPlayer)
            {
                p.ShowHand();
            }
        }
    }

    private void Betting()
    {
        for(int i = _startingPlayer; i < _startingPlayer+_players.Count; i++)
        {
            if(_currentBets[i%_players.Count] == -1) continue; // skip folded players
            var action = _players[i%_players.Count].TakeTurn(_maxCurrentBet, _currentBets[i%_players.Count]);
            _currentBets[i%_players.Count] = action[1];
        }
        foreach(var a in _currentBets) _pot += a;
        Array.Fill(_currentBets, 0);
        Console.WriteLine($"Pot is {_pot}");
    }

    private void Flop()
    {
        _burn.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        foreach(Card c in _table)
        {
            Console.Write(c.GetPrettyString());
        }
    }

    private void Turn()
    {
        _burn.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        foreach(Card c in _table)
        {
            Console.Write(c.GetPrettyString());
        }
    }
    private void River()
    {
        _burn.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        foreach(Card c in _table)
        {
            Console.Write(c.GetPrettyString());
        }
    }
    private void EndRound()
    {
        RankedHand currentHand;
        RankedHand bestHand = new();
        int bestRank = 0;
        int bestPlayer = 0;
        for(int i = _startingPlayer; i < _startingPlayer+_players.Count; i++)
        {
            _players[i%_players.Count].ShowHand();
            currentHand = _builder.GetBestHand(_table.Concat(_players[i%_players.Count].GetHand()).ToList());
            Console.WriteLine($"{_players[bestPlayer].GetName()} has");
            foreach(Card c in currentHand._hand)
            {
                Console.Write(c.GetPrettyString());
            }
            if(currentHand._rank > bestRank)
            {
                bestRank = currentHand._rank;
                bestHand = currentHand;
                bestPlayer = i%_players.Count;
            }
        }
        Console.WriteLine($"{_players[bestPlayer].GetName()} wins with ");
        foreach(Card c in bestHand._hand)
            {
                Console.Write(c.GetPrettyString());
            }
    }
}