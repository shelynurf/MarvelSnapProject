using MarvelSnapProject;

public class LocationInfo{
    private Dictionary<IPlayer, int> _scoreLoc = new Dictionary<IPlayer, int>();
    private Dictionary<IPlayer, List<ICard>> _cardsLoc = new Dictionary<IPlayer,List<ICard>>();

    public bool InitLocPlayer(IEnumerable<IPlayer> players){
        foreach (IPlayer player in players){
            _scoreLoc.Add(player, 0);
            _cardsLoc.Add(player, new List<ICard>());
        }
        return true;
    }

    public Dictionary<IPlayer, List<ICard>> GetCardsOnLoc()
    {
        return _cardsLoc;
    }

    public List<ICard> GetCardsOnLoc(IPlayer player)
    {
        return _cardsLoc[player];
    }

    public Dictionary<IPlayer, int> GetLocScore()
    {
        return _scoreLoc;
    }

    public int GetLocScore(IPlayer player)
    {
        return _scoreLoc[player];
    }

    public bool PlaceCard(IPlayer player, ICard card)
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

    
}

