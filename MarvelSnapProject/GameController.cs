namespace MarvelSnapProject;

public class GameController
{
    private int _round = 0;
    private Dictionary<Iplayer, PlayerInfo> _playersInfo = new();
    private List<Ilocation> _locations = new();
    private List<Ilocation> _cards = new();
    // private Iplayer _turn = new();

    public bool AddNewPlayer(Iplayer player)
    {
        if (_playersInfo.Count < 2)
        {
            if (!_playersInfo.ContainsKey(player))
            {
                foreach (Iplayer regPlayer in _playersInfo.Keys)
                {

                    if (regPlayer.GetPlayerName() == player.GetPlayerName() || regPlayer.GetPlayerID() == player.GetPlayerID())
                    {
                        return false;
                    }
                }
                PlayerInfo playerInfo = new();
                _playersInfo.Add(player, playerInfo);
                return true;
            }
        }
        return false;

    }
    public IEnumerable<Iplayer> ListAllPlayer()
    {
        List<Iplayer> players = new();
        foreach (var kvp in _playersInfo)
        {
            players.Add(kvp.Key);
        }
        return players;
    }
    public bool RemovePlayer(Iplayer player)
    {
        if (_playersInfo.ContainsKey(player)){
            _playersInfo.Remove(player);
            return true;
        }
        return false;
    }
    public bool SetPlayerStatus(Iplayer player, PlayerStatus status)
    {
        return true;
    }
    // public PlayerStatus GetPlayerStatus(Iplayer player){

    // }
    public bool AddNewLocation(Ilocation location)
    {
        return true;
    }
    // public IEnumerable<Ilocation> ListAllLocation(){

    // }
    public bool AddNewCard(ICard card)
    {
        return true;
    }
    public bool RemoveCard(ICard card)
    {
        return true;
    }
    // public string GetCardInfo(ICard card){

    // }
    // public IEnumerable<string> ListAllCard(){

    // }
    public bool AddNewCardToPlayer(Iplayer player, ICard card)
    {
        return true;
    }
    public bool PopCardFromPlayer(Iplayer player, ICard card)
    {
        return true;
    }
    // public List<ICard> ListAllCardFromPlayer(Iplayer player){

    // }
    public bool AddNewCardToLocation(Ilocation location, Iplayer player, ICard card)
    {
        return true;
    }
    public bool IsCardFullInLocation(Ilocation location)
    {
        return true;
    }
    // public Iplayer GetWinner(Ilocation location){

    // }
    public bool SetGameMode(GameMode gameMode)
    {
        return true;
    }


}
