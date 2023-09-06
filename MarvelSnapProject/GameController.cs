namespace MarvelSnapProject;

public class GameController
{
    private int _round = 0;
    private Dictionary<IPlayer, PlayerInfo> _playersInfo = new();
    private Dictionary<Ilocation, LocationInfo> _locationsInfo = new();
    private List<Ilocation> _locations = new();
    private List<Ilocation> _cards = new();
    private GameStatus _gameStatus = GameStatus.NotStarted;
    private MarvelSerialized _marvelSer = new MarvelSerialized();
    private List<MarvelCard> _allCards = new();
    private List<MarvelLocation> _allLocations = new();
    private Random _random = new Random();
    private List<Ilocation> _randomLoc = new();
    
    // private IPlayer _turn = new();

    /// <summary>
    /// Add instance of player to join the game
    /// </summary>
    /// <param name="player">player's instance</param>
    /// <returns>True if success</returns>
    public bool AddNewPlayer(IPlayer player)
    {
        if (_playersInfo.Count < 2)
        {
            if (!_playersInfo.ContainsKey(player))
            {
                foreach (IPlayer regPlayer in _playersInfo.Keys)
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
    // public bool AddNewPlayer(IPlayer player)
    // {
    //     PlayerInfo playerInfo = new();
    //     _playersInfo.Add(player, playerInfo);
    //     return true;
    // }

    

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

    /// <summary>
    /// Checking current round of game
    /// </summary>
    /// <returns>current round</returns>
    public int CheckRound(){
        return _round;
    }

    /// <summary>
    /// Get status of the remaining game, are it not started, ongoing, or finished.
    /// </summary>
    /// <returns>Return Enum of Game Status</returns>
    public GameStatus GetGameStatus(){
        return _gameStatus;
    }

    /// <summary>
    /// Continue the game to the next round
    /// </summary>
    /// <returns></returns>
    public bool NextRound(){
        if (_gameStatus == GameStatus.NotStarted && _playersInfo.Count == 2){
            _gameStatus = GameStatus.Running;
            _round += 1;
        }
        else if (_gameStatus == GameStatus.Running){
            if (_round == 6){
                _gameStatus = GameStatus.Finished;
            }
            else {
                _round += 1;
            }
        }
        
        foreach (PlayerInfo info in _playersInfo.Values){
            info.SetEnergy(_round);
        }
        return true;
    }

    public List<MarvelCard> GetAllCards(){
        _allCards = _marvelSer.ImportCards();
        return _allCards;
    }

    public List<MarvelLocation> GetAllLocations(){
        _allLocations = _marvelSer.ImportLocations();
        return _allLocations;
    }

    public bool SetPlayerDeck(IPlayer player, List<int> listCardIndex){
        // PlayerInfo info = _playersInfo[player];
        // Random random = new Random();
        // List<int> randomList = new List<int>();

        // while (randomList.Count < 12)
        // {
        //     int indexCard = random.Next(0, _allCards.Count);
        //     if (!randomList.Contains(indexCard)){
        //         randomList.Add(indexCard);
        //     }
        // }
        // foreach(int index in randomList){
        //     ICard card = _allCards[index].Copy();
        //     info.AddCardToDeck(card);
        // }
        // return true;
        PlayerInfo info = _playersInfo[player];
        // Random random = new Random();
        // int[] indexCard = new int[12] ;
        List<int> indexCard = listCardIndex;
        // List<int> indexList = listCard;
        // while (randomList.Count < 12){
        //     int indexCard = random.Next(_allCards.Count);
        //     if (!randomList.Contains(indexCard)){
        //         randomList.Add(indexCard);
        //     }
        // }
        foreach(int index in indexCard){
            MarvelCard card = _allCards[index].Copy();
            info.AddCardToDeck(card);
        }
        return true;
    }

    public List<MarvelCard> GetPlayerDeck(IPlayer player){
        return _playersInfo[player].GetDeck();
    }

    public bool GenerateCard(IPlayer player){
        PlayerInfo info = _playersInfo[player];
        // Random random = new Random();
        List<MarvelCard> deck = info.GetDeck();
        List<int> listIndex = new List<int>();
        if (_round == 1 ){
            while (listIndex.Count < 4){
                int ind = _random.Next(0, deck.Count);
                if (!listIndex.Contains(ind)){
                    listIndex.Add(ind);
                }
            }
        }
        else {
            int ind = _random.Next(0, deck.Count);
            if (!listIndex.Contains(ind)){
                    listIndex.Add(ind);
                }
        }

        foreach (int ind in listIndex){
            MarvelCard card = deck[ind].Copy();
            info.AddCard(card);
        }
        return true;


        // int randomIndex = random.Next(0, deck.Count);
        // MarvelCard card = deck[randomIndex].Copy();
        // return true;
    }

    public List<ICard> GetPlayerCards(IPlayer player){
        return _playersInfo[player].GetCards();
    }

    /// <summary>
    /// Generate 3 random location on the game.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Ilocation> GenerateLocation(){
        List<MarvelLocation> locations = new List<MarvelLocation>();
        // List<int> listIndex = new List<int>();
        while (locations.Count < 3){
            int index = _random.Next(0, _allLocations.Count);
            if (!locations.Contains(_allLocations[index])){
                locations.Add(_allLocations[index]);
            }
        }
        foreach (MarvelLocation loc in locations){
            LocationInfo info = new LocationInfo();
            info.InitLocPlayer(ListAllPlayer());
            _locationsInfo.Add(loc, info);
        }

        return locations;
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


