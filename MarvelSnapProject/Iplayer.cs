namespace MarvelSnapProject;

public interface Iplayer{
    public string GetPlayerName();
    public int GetPlayerID();
    public bool SetPlayerName(string name);
    public bool SetPlayerID(int id);
}