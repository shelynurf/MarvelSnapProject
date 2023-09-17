using MarvelSnapProject;

public class LocationInfo
{
    private Dictionary<IPlayer, int> _scoreLoc = new Dictionary<IPlayer, int>();
    private Dictionary<IPlayer, List<MarvelCard>> _cardsLoc = new Dictionary<IPlayer, List<MarvelCard>>();
    // private List<IPlayer> _winner = new();
    private Dictionary<IPlayer, PlayerInfo> _playerLocInfo = new();

    public bool InitLocPlayer(IEnumerable<IPlayer> players)
    {
        foreach (IPlayer player in players)
        {
            _scoreLoc.Add(player, 0);
            _cardsLoc.Add(player, new List<MarvelCard>());
        }
        return true;
    }

    public Dictionary<IPlayer, List<MarvelCard>> GetCardsOnLoc()
    {
        return _cardsLoc;
    }

    public List<MarvelCard> GetCardsOnLoc(IPlayer player)
    {
        return _cardsLoc[player];
    }

    public bool SetCardsOnLoc(IPlayer player, MarvelCard card)
    {
        _cardsLoc[player].Add(card);
        return true;
    }

    public Dictionary<IPlayer, int> GetLocScore()
    {
        return _scoreLoc;
    }

    public int GetLocScore(IPlayer player)
    {
        int score = _scoreLoc[player];
        return score;
    }

    public bool SetLocScore(IPlayer player, int score)
    {
        _scoreLoc[player] = score;
        return true;
    }

    public bool AddScore(IPlayer player, int add)
    {
        _scoreLoc[player] += add;
        return true;
    }

    public bool PlaceCard(IPlayer player, MarvelCard card)
    {
        _cardsLoc[player].Add(card);
        CalculateScore(player, card);
        return true;
    }

    public bool CalculateScore(IPlayer player, ICard card)
    {
        _scoreLoc[player] += card.GetCardPower();
        return true;
    }

    // public List<IPlayer> GetLocWinner()
    // {
    //     Dictionary<IPlayer, int> sortedScoreLoc = _scoreLoc.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    //     if (sortedScoreLoc.ElementAt(0).Value != sortedScoreLoc.ElementAt(1).Value)
    //     {
    //         IPlayer winner = sortedScoreLoc.ElementAt(0).Key;
    //         _winner.Add(winner);
    //         winner.SetPlayerStatus(PlayerStatus.Win);
    //     }
    //     else{
    //         foreach (var kvp in sortedScoreLoc)
    //         {
    //             _winner.Add(kvp.Key);
    //             kvp.Key.SetPlayerStatus(PlayerStatus.Draw);
    //         }
    //     }
    //     foreach(var kvp in sortedScoreLoc)
    //     {
    //         PlayerStatus status = kvp.Key.GetPlayerStatus();
    //         if (status != PlayerStatus.Win && status != PlayerStatus.Draw)
    //         {
    //             kvp.Key.SetPlayerStatus(PlayerStatus.Lose);
    //         }
    //     }
    //     return _winner;
    // }
    public IPlayer GetLocWinner()
    {
        int highest = 0;
        IPlayer winner = null;
        foreach (var kvp in _scoreLoc)
        {
            if (kvp.Value > highest)
            {
                highest = kvp.Value;
                winner = kvp.Key;
            }
            else if (kvp.Value == highest)
            {
                winner = null;
            }
        }
        return winner;
    }
}

