using MarvelSnapProject.Component.Card;

namespace MarvelSnapProject;

public class GameController
{
    private int _round = 0;
    private Dictionary<Iplayer, PlayerInfo> _playersInfo = new();
    private List<Ilocation> _locations = new();
    private List<Ilocation> _cards = new();
    // private Iplayer _turn = new();

    /// <summary>
    /// Add instance of player to join the game
    /// </summary>
    /// <param name="player">player's instance</param>
    /// <returns>True if success</returns>
    // public bool AddNewPlayer(Iplayer player)
    // {
    //     if (_playersInfo.Count < 2)
    //     {
    //         if (!_playersInfo.ContainsKey(player))
    //         {
    //             foreach (Iplayer regPlayer in _playersInfo.Keys)
    //             {

    //                 if (regPlayer.GetPlayerName() == player.GetPlayerName() || regPlayer.GetPlayerID() == player.GetPlayerID())
    //                 {
    //                     return false;
    //                 }
    //             }
    //             PlayerInfo playerInfo = new();
    //             _playersInfo.Add(player, playerInfo);
    //             return true;
    //         }
    //     }
    //     return false;
    // }
    public bool AddNewPlayer(Iplayer player)
    {
        PlayerInfo playerInfo = new();
        _playersInfo.Add(player, playerInfo);
        return true;
    }

    /// <summary>
    /// Remove player instance from the game
    /// </summary>
    /// <param name="player">player to be delete</param>
    /// <returns>true if success</returns>
    public bool RemovePlayer(Iplayer player)
    {
        _playersInfo.Remove(player);
        return true;
    }

    /// <summary>
    /// Get list of player's name and ID
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Iplayer> ListAllPlayer()
    {
        List<Iplayer> players = new();
        foreach (var kvp in _playersInfo)
        {
            players.Add(kvp.Key);

        }
        return players;
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

    // public bool AddPlayerDeck(Iplayer player, ICard card){
    //     PlayerInfo playerInfo = new PlayerInfo();
    //     playerInfo.AddCardToDeck(new MarvelCard(card));

    //     return true;
    // }

    public IEnumerable<ICard> GetAllCards()
    {
        // List<MarvelCard> allCards = new(){
        //     new("Hawkeye", 1, 1, Enum.CardType.OnReveal, Enum.CardSkill.Hawkeye),
        //     new("Misty Knight", 1, 2, Enum.CardType.Normal, Enum.CardSkill.MistyKnight),
        //     new("Abomination", 5, 9, Enum.CardType.Normal, Enum.CardSkill.Abomination),
        //     new("Cyclops", 3, 4, Enum.CardType.Normal, Enum.CardSkill.Cyclops),
        //     new("Hulk", 6, 12, Enum.CardType.Normal, Enum.CardSkill.Hulk),
        //     new("Iron Man", 5, 0, Enum.CardType.OnGoing, Enum.CardSkill.IronMan),
        //     new("Medusa", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.Medusa),
        //     new("Punisher", 3, 2, Enum.CardType.OnGoing, Enum.CardSkill.Punisher),
        //     new("Quicksilver", 1, 2, Enum.CardType.Normal, Enum.CardSkill.Quicksilver),
        //     new("Sentinel", 2, 3, Enum.CardType.OnReveal, Enum.CardSkill.Sentinel),
        //     new("Shocker", 2, 3, Enum.CardType.Normal, Enum.CardSkill.Shocker),
        //     new("Star-Lord", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.StarLord),
        //     new("The Thing", 4, 6, Enum.CardType.Normal, Enum.CardSkill.TheThing),
        //     new("Jessica Jones", 4, 4, Enum.CardType.OnReveal, Enum.CardSkill.JessicaJones),
        //     new("Ant Man", 1, 1, Enum.CardType.OnGoing, Enum.CardSkill.AntMan),
        //     new("Squirrel", 1, 1, Enum.CardType.Normal, Enum.CardSkill.Squirrel)};

            List<MarvelCard> cards = new List<MarvelCard>();
            cards.Add(new("Hawkeye", 1, 1, Enum.CardType.OnReveal, Enum.CardSkill.Hawkeye));
            cards.Add(new("Misty Knight", 1, 2, Enum.CardType.Normal, Enum.CardSkill.MistyKnight));
            cards.Add(new("Abomination", 5, 9, Enum.CardType.Normal, Enum.CardSkill.Abomination));
            cards.Add(new("Cyclops", 3, 4, Enum.CardType.Normal, Enum.CardSkill.Cyclops));
            cards.Add(new("Hulk", 6, 12, Enum.CardType.Normal, Enum.CardSkill.Hulk));
            cards.Add(new("Iron Man", 5, 0, Enum.CardType.OnGoing, Enum.CardSkill.IronMan));
            cards.Add(new("Medusa", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.Medusa));
            cards.Add(new("Punisher", 3, 2, Enum.CardType.OnGoing, Enum.CardSkill.Punisher));
            cards.Add(new("Quicksilver", 1, 2, Enum.CardType.Normal, Enum.CardSkill.Quicksilver));
            cards.Add(new("Sentinel", 2, 3, Enum.CardType.OnReveal, Enum.CardSkill.Sentinel));
            cards.Add(new("Shocker", 2, 3, Enum.CardType.Normal, Enum.CardSkill.Shocker));
            cards.Add(new("Star-Lord", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.StarLord));
            cards.Add(new("The Thing", 4, 6, Enum.CardType.Normal, Enum.CardSkill.TheThing));
            cards.Add(new("Jessica Jones", 4, 4, Enum.CardType.OnReveal, Enum.CardSkill.JessicaJones));
            cards.Add(new("Ant Man", 1, 1, Enum.CardType.OnGoing, Enum.CardSkill.AntMan));
            cards.Add(new("Squirrel", 1, 1, Enum.CardType.Normal, Enum.CardSkill.Squirrel));
            

           

        List<ICard> allCards = new();
        foreach (MarvelCard card in cards)
        {
            // List<string> cardsName = new();
            allCards.Add(card);
            
        }
        return allCards;

    

    }
};


// public bool AddNewCardToLocation(Ilocation location, Iplayer player, ICard card)
// {
//     return true;
// }
// public bool IsCardFullInLocation(Ilocation location)
// {
//     return true;
// }
// public Iplayer GetWinner(Ilocation location){

// }
// public bool SetGameMode(GameMode gameMode)
// {
//     return true;
// }



