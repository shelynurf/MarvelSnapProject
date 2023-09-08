namespace MarvelSnapProject;

public interface IPlayer{

    /// <summary>
    /// Get player's name and return to string.
    /// </summary>
    /// <returns>Name of player</returns>
    public string GetPlayerName();
    /// <summary>
    /// Get player's ID and return to integer.
    /// </summary>
    /// <returns>ID of player</returns>
    public int GetPlayerID();
    /// <summary>
    /// Set value as a player's name
    /// </summary>
    /// <param name="name">Current player's name</param>
    /// <returns>True if success</returns>
    public bool SetPlayerName(string name);
    /// <summary>
    /// Set value as player's ID
    /// </summary>
    /// <param name="id">Current player's ID</param>
    /// <returns>True if success</returns>
    public bool SetPlayerID(int id);
    public PlayerStatus GetPlayerStatus();

    public bool SetPlayerStatus(PlayerStatus status);
}