namespace MarvelSnapProject;

public class MarvelPlayer : IPlayer{
    private string _playerName;
    private int _playerID;
    private PlayerStatus _playerStatus;

    public MarvelPlayer(string playerName, int playerID){
        _playerName = playerName;
        _playerID = playerID;
    }
    public string GetPlayerName(){
        return _playerName;
    }
    public int GetPlayerID(){
        return _playerID;
    }
    public bool SetPlayerName(string name){
        _playerName = name;
        return true;
    }

    public bool SetPlayerID(int id){
        _playerID = id;
        return true;
    }

    public PlayerStatus GetPlayerStatus(){
        return _playerStatus;
    }

    public bool SetPlayerStatus(PlayerStatus status)
    {
        _playerStatus = status;
        return true;
    }
}
