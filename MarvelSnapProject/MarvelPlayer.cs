namespace MarvelSnapProject;

public class MarvelPlayer : Iplayer{
    private string _playerName;
    private int _playerID;
    private PlayerStatus _playerStatus;
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
}
