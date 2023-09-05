namespace MarvelSnapProject;

public class GameController
{
    private int _round = 0;
    private Dictionary<IPlayer, PlayerInfo> _playersInfo = new();
    private List<Ilocation> _locations = new();
    private List<Ilocation> _cards = new();

    
    // private IPlayer _turn = new();

    /// <summary>
    /// Add instance of player to join the game
    /// </summary>
    /// <param name="player">player's instance</param>
    /// <returns>True if success</returns>
    // public bool AddNewPlayer(IPlayer player)
    // {
    //     if (_playersInfo.Count < 2)
    //     {
    //         if (!_playersInfo.ContainsKey(player))
    //         {
    //             foreach (IPlayer regPlayer in _playersInfo.Keys)
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
    public bool AddNewPlayer(IPlayer player)
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
    public bool RemovePlayer(IPlayer player)
    {
        _playersInfo.Remove(player);
        return true;
    }

    /// <summary>
    /// Get list of player's name and ID
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IPlayer> ListAllPlayer()
    {
        List<IPlayer> players = new();
        foreach (var kvp in _playersInfo)
        {
            players.Add(kvp.Key);

        }
        return players;
    }

    public int CheckRound(){
        return _round;
    }

    public bool NextRound(){
        _round += 1;
        return true;
    }

    public void AddlayerDeck(IPlayer player, ICard cards){
        PlayerInfo info = _playersInfo[player];
        Random random = new Random();
        info.AddCardToDeck(cards);
    }

    public bool SetPlayerStatus(IPlayer player, PlayerStatus status)
    {
        return true;
    }
    // public PlayerStatus GetPlayerStatus(IPlayer player){

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
    public bool AddNewCardToPlayer(IPlayer player, ICard card)
    {
        return true;
    }
    public bool PopCardFromPlayer(IPlayer player, ICard card)
    {
        return true;
    }
    // public List<ICard> ListAllCardFromPlayer(IPlayer player){

    // }

    // public bool AddPlayerDeck(IPlayer player, ICard card){
    //     PlayerInfo playerInfo = new PlayerInfo();
    //     playerInfo.AddCardToDeck(new MarvelCard(card));

    //     return true;
    // }

    // public IEnumerable<ICard> GetAllCards()
    // {
    //     // List<MarvelCard> allCards = new(){
    //     //     new("Hawkeye", 1, 1, Enum.CardType.OnReveal, Enum.CardSkill.Hawkeye),
    //     //     new("Misty Knight", 1, 2, Enum.CardType.Normal, Enum.CardSkill.MistyKnight),
    //     //     new("Abomination", 5, 9, Enum.CardType.Normal, Enum.CardSkill.Abomination),
    //     //     new("Cyclops", 3, 4, Enum.CardType.Normal, Enum.CardSkill.Cyclops),
    //     //     new("Hulk", 6, 12, Enum.CardType.Normal, Enum.CardSkill.Hulk),
    //     //     new("Iron Man", 5, 0, Enum.CardType.OnGoing, Enum.CardSkill.IronMan),
    //     //     new("Medusa", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.Medusa),
    //     //     new("Punisher", 3, 2, Enum.CardType.OnGoing, Enum.CardSkill.Punisher),
    //     //     new("Quicksilver", 1, 2, Enum.CardType.Normal, Enum.CardSkill.Quicksilver),
    //     //     new("Sentinel", 2, 3, Enum.CardType.OnReveal, Enum.CardSkill.Sentinel),
    //     //     new("Shocker", 2, 3, Enum.CardType.Normal, Enum.CardSkill.Shocker),
    //     //     new("Star-Lord", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.StarLord),
    //     //     new("The Thing", 4, 6, Enum.CardType.Normal, Enum.CardSkill.TheThing),
    //     //     new("Jessica Jones", 4, 4, Enum.CardType.OnReveal, Enum.CardSkill.JessicaJones),
    //     //     new("Ant Man", 1, 1, Enum.CardType.OnGoing, Enum.CardSkill.AntMan),
    //     //     new("Squirrel", 1, 1, Enum.CardType.Normal, Enum.CardSkill.Squirrel)};

    //     List<MarvelCard> cards = new List<MarvelCard>();
    //     cards.Add(new("Hawkeye", 1, 1, Enum.CardType.OnReveal, Enum.CardSkill.Hawkeye));
    //     cards.Add(new("Misty Knight", 1, 2, Enum.CardType.Normal, Enum.CardSkill.MistyKnight));
    //     cards.Add(new("Abomination", 5, 9, Enum.CardType.Normal, Enum.CardSkill.Abomination));
    //     cards.Add(new("Cyclops", 3, 4, Enum.CardType.Normal, Enum.CardSkill.Cyclops));
    //     cards.Add(new("Hulk", 6, 12, Enum.CardType.Normal, Enum.CardSkill.Hulk));
    //     cards.Add(new("Iron Man", 5, 0, Enum.CardType.OnGoing, Enum.CardSkill.IronMan));
    //     cards.Add(new("Medusa", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.Medusa));
    //     cards.Add(new("Punisher", 3, 2, Enum.CardType.OnGoing, Enum.CardSkill.Punisher));
    //     cards.Add(new("Quicksilver", 1, 2, Enum.CardType.Normal, Enum.CardSkill.Quicksilver));
    //     cards.Add(new("Sentinel", 2, 3, Enum.CardType.OnReveal, Enum.CardSkill.Sentinel));
    //     cards.Add(new("Shocker", 2, 3, Enum.CardType.Normal, Enum.CardSkill.Shocker));
    //     cards.Add(new("Star-Lord", 2, 2, Enum.CardType.OnReveal, Enum.CardSkill.StarLord));
    //     cards.Add(new("The Thing", 4, 6, Enum.CardType.Normal, Enum.CardSkill.TheThing));
    //     cards.Add(new("Jessica Jones", 4, 4, Enum.CardType.OnReveal, Enum.CardSkill.JessicaJones));
    //     cards.Add(new("Ant Man", 1, 1, Enum.CardType.OnGoing, Enum.CardSkill.AntMan));
    //     cards.Add(new("Squirrel", 1, 1, Enum.CardType.Normal, Enum.CardSkill.Squirrel));

    //     List<ICard> allCards = new();
    //     foreach (MarvelCard card in cards)
    //     {
    //         // List<string> cardsName = new();
    //         allCards.Add(card);

    //     }
    //     return allCards;



    // }
};

// public IEnumerable<Ilocation> GetAllLocations()
// {
//     List<MarvelLocation> allLocation = new List<MarvelLocation>();
//     {
//             new("Necrosha", Enum.LocationSkill.Necrosha),
//             new("Central Park", Enum.LocationSkill.CentralPark),
//             new("Negative Zone", Enum.LocationSkill.NegativeZone),
//             new("The Superflow", Enum.LocationSkill.TheSuperflow),
//             new("Asgard", Enum.LocationSkill.Asgard),
//             new("Lemuria", Enum.LocationSkill.Lemuria),
//             new("The Big House", Enum.LocationSkill.TheBigHouse),
//             new("Subterranea", Enum.LocationSkill.Subterranea),

//         };
//     return allLocation;
// }


// public bool AddNewCardToLocation(Ilocation location, IPlayer player, ICard card)
// {
//     return true;
// }
// public bool IsCardFullInLocation(Ilocation location)
// {
//     return true;
// }
// public IPlayer GetWinner(Ilocation location){

// }
// public bool SetGameMode(GameMode gameMode)
// {
//     return true;
// }



	// // ENTER PLAYER'S IDENTITY
	// 	string? name;
	// 	IPlayer player1, player2;
	// 	do 
	// 	{
	// 		Console.Write("Input first player's name : ");	
	// 		name = Console.ReadLine();
	// 		player1 = new HumanPlayer(name);
	// 	} while (name == "" || player1.GetName() == "");
	// 	// IPlayer player1 = new HumanPlayer(name);
	// 	gameRunner.AddPlayer(player1);
		
	// 	do
	// 	{
	// 		Console.Write("Input second player's name : ");
	// 		name= Console.ReadLine();
	// 		player2 = new HumanPlayer(name);
	// 	} while (name == "" || !gameRunner.AddPlayer(player2));
	// 	// IPlayer player2 = new HumanPlayer(name);

    //     public bool AddPlayer(IPlayer player)
	// {
	// 	if (_playerInfo.Count < 2)
	// 	{
	// 		if (!_playerInfo.ContainsKey(player))
	// 		{
	// 			foreach (IPlayer assigned in _playerInfo.Keys)
	// 			{
	// 				if (assigned.GetId() == player.GetId() || assigned.GetName() == player.GetName()) // checking if id or name has already assigned
	// 				{
	// 					return false;			
	// 				}
	// 			}
	// 			PlayerConfig config = new();
	// 			_playerInfo.Add(player, config);
	// 			return true;
	// 		}
	// 	}
	// 	return false;
	// }


