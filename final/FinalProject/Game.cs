public class Game
{
    private List<Player> _players;
    private int _pot;
    private Deck _deck;
    private HandBuilder _builder;
    private List<Card> _table;
    private List<Card> _burn;
    private int _startingPlayer;
    //private int _minRaise = 100; //future implementation
    private int _maxCurrentBet = 0;
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
            if(action[1] > _maxCurrentBet) _maxCurrentBet = action[1];
            _currentBets[i%_players.Count] = action[1];
        }
        for(int i = 0; i < _currentBets.Length; i++)
        {
            if(_currentBets[i] == -1) continue;
            _pot += _currentBets[i];
            _currentBets[i] = 0;
        } 
        Console.WriteLine($"Pot is {_pot}");
        _maxCurrentBet = 0;
    }

    private void Flop()
    {
        _burn.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        Console.WriteLine("Table cards:\n");
        foreach(Card c in _table)
        {
            Console.Write(c.GetPrettyString());
            Console.Write(" ");
        }
        Console.Write("\n");
    }

    private void Turn()
    {
        _burn.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        Console.WriteLine("Table cards:\n");
        foreach(Card c in _table)
        {
            Console.Write(c.GetPrettyString());
            Console.Write(" ");
        }
        Console.Write("\n");
    }
    private void River()
    {
        _burn.Add(_deck.Deal());
        _table.Add(_deck.Deal());
        Console.WriteLine("Table cards:\n");
        foreach(Card c in _table)
        {
            Console.Write(c.GetPrettyString());
            Console.Write(" ");
        }
        Console.Write("\n");
    }
    private void EndRound()
    {
        RankedHand currentHand;
        RankedHand bestHand = new();
        int bestRank = 0;
        int bestPlayer = 0;
        for(int i = _startingPlayer; i < _startingPlayer+_players.Count; i++)
        {
            if(_currentBets[i%_players.Count] == -1) continue; // skip folded players
            Console.WriteLine($"{_players[i%_players.Count].GetName()} has");
            _players[i%_players.Count].ShowHand();
            currentHand = _builder.GetBestHand(_table.Concat(_players[i%_players.Count].GetHand()).ToList());
            currentHand.DisplayHand();
            // foreach(Card c in currentHand._hand)
            // {
            //     Console.Write(c.GetPrettyString());
            // }
            Console.Write("\n");
            if(currentHand._rank > bestRank)
            {
                bestRank = currentHand._rank;
                bestHand = currentHand;
                bestPlayer = i%_players.Count;
            }
        }
        Console.WriteLine($"{_players[bestPlayer].GetName()} wins with ");
        bestHand.DisplayHand();
    }
}