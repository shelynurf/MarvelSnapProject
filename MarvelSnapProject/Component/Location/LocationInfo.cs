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
}

