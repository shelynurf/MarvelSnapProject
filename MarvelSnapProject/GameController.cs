namespace MarvelSnapProject;

public class GameController
{
    private Dictionary<Iplayer, PlayerInfo> _playersInfo;
    private List<Ilocation> _locations;
    private List<Ilocation> _cards;
    private Iplayer _turn;

    public bool AddNewPlayer(Iplayer player){
        return true;
    }
    // public IEnumerable<Iplayer> ListAllPlayer(){
        
    // }
    public bool RemovePlayer(Iplayer player){
        return true;
    }
    public bool SetPlayerStatus(Iplayer player, PlayerStatus status){
        return true;
    }
    // public PlayerStatus GetPlayerStatus(Iplayer player){
        
    // }
    public bool AddNewLocation(Ilocation location){
        return true;
    }
    // public IEnumerable<Ilocation> ListAllLocation(){

    // }
    public bool AddNewCard(ICard card){
        return true;
    }
    public bool RemoveCard(ICard card){
        return true;
    }
    // public string GetCardInfo(ICard card){

    // }
    // public IEnumerable<string> ListAllCard(){

    // }
    public bool AddNewCardToPlayer(Iplayer player, ICard card){
        return true;
    }
    public bool PopCardFromPlayer(Iplayer player, ICard card){
        return true;
    }
    // public List<ICard> ListAllCardFromPlayer(Iplayer player){

    // }
    public bool AddNewCardToLocation(Ilocation location, Iplayer player, ICard card){
        return true;
    }
    public bool IsCardFullInLocation(Ilocation location){
        return true;
    }
    // public Iplayer GetWinner(Ilocation location){

    // }
    public bool SetGameMode(GameMode gameMode){
        return true;
    }


}
