namespace MarvelSnapProject;

public class GameController
{
    private int _round = 0;
    private Dictionary<IPlayer, PlayerInfo> _playersInfo = new();
    private Dictionary<MarvelLocation, LocationInfo> _locationsInfo = new();
    private List<Ilocation> _locations = new();
    private List<Ilocation> _cards = new();
    private GameStatus _gameStatus = GameStatus.NotStarted;
    private MarvelSerialized _marvelSer = new MarvelSerialized();
    private List<MarvelCard> _allCards = new List<MarvelCard>();
    private List<MarvelLocation> _allLocations = new();
    private Random _random = new Random();
    private List<MarvelLocation> _randomLoc = new();

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
    public int CheckRound()
    {
        return _round;
    }

    /// <summary>
    /// Get status of the remaining game, are it not started, ongoing, or finished.
    /// </summary>
    /// <returns>Return Enum of Game Status</returns>
    public GameStatus GetGameStatus()
    {
        return _gameStatus;
    }

    /// <summary>
    /// Continue the game to the next round
    /// </summary>
    /// <returns></returns>
    public bool NextRound()
    {
        if (_gameStatus == GameStatus.NotStarted && _playersInfo.Count == 2)
        {
            _gameStatus = GameStatus.Running;
            _round += 1;
        }
        else if (_gameStatus == GameStatus.Running)
        {
            if (_round == 6)
            {
                _gameStatus = GameStatus.Finished;
            }
            else
            {
                _round += 1;
            }
        }

        foreach (PlayerInfo info in _playersInfo.Values)
        {
            info.SetEnergy(_round);
        }
        return true;
    }

    public List<MarvelCard> GetAllCards()
    {
        _allCards = _marvelSer.ImportCards();
        return _allCards;
    }

    public List<MarvelLocation> GetAllLocations()
    {
        _allLocations = _marvelSer.ImportLocations();
        return _allLocations;
    }

    public bool SetPlayerDeck(IPlayer player, List<int> listCardIndex)
    {
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
        foreach (int index in indexCard)
        {
            MarvelCard card = _allCards[index].Copy();
            info.AddCardToDeck(card);
        }
        return true;
    }

    public List<MarvelCard> GetPlayerDeck(IPlayer player)
    {
        return _playersInfo[player].GetDeck();
    }

    /// <summary>
    /// Generate cards in hand of each round
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public bool GenerateCard(IPlayer player)
    {
        PlayerInfo info = _playersInfo[player];
        // Random random = new Random();
        List<MarvelCard> deck = info.GetDeck();
        List<int> listIndex = new List<int>();
        if (_round == 1)
        {
            while (listIndex.Count < 4)
            {
                int ind = _random.Next(0, deck.Count);
                if (!listIndex.Contains(ind))
                {
                    listIndex.Add(ind);
                }
            }
        }
        else
        {
            int ind = _random.Next(0, deck.Count);
            if (!listIndex.Contains(ind))
            {
                listIndex.Add(ind);
            }
        }

        foreach (int ind in listIndex)
        {
            MarvelCard card = deck[ind].Copy();
            info.AddCard(card);
        }
        return true;


        // int randomIndex = random.Next(0, deck.Count);
        // MarvelCard card = deck[randomIndex].Copy();
        // return true;
    }

    public List<MarvelCard> GetPlayerCards(IPlayer player)
    {
        return _playersInfo[player].GetCards();
    }

    /// <summary>
    /// Generate 3 random location on the game.
    /// </summary>
    /// <returns></returns>
    public bool GenerateLocation()
    {
        // List<MarvelLocation> locations = new List<MarvelLocation>();
        // // List<int> listIndex = new List<int>();
        // while (locations.Count < 3){
        //     int index = _random.Next(0, _allLocations.Count);
        //     if (!locations.Contains(_allLocations[index])){
        //         locations.Add(_allLocations[index]);
        //     }
        // }
        // foreach (MarvelLocation loc in locations){
        //     LocationInfo info = new LocationInfo();
        //     info.InitLocPlayer(ListAllPlayer());
        //     _locationsInfo.Add(loc, info);
        // }

        // return locations;
        // List<MarvelLocation> locations = new List<MarvelLocation>();
        // List<int> listIndex = new List<int>();
        while (_randomLoc.Count < 3)
        {
            int index = _random.Next(0, _allLocations.Count);
            if (!_randomLoc.Contains(_allLocations[index]))
            {
                _randomLoc.Add(_allLocations[index]);
            }
        }
        foreach (MarvelLocation loc in _randomLoc)
        {
            LocationInfo info = new LocationInfo();
            info.InitLocPlayer(ListAllPlayer());
            _locationsInfo.Add(loc, info);
        }

        return true;
    }

    public List<MarvelLocation> GetLocations()
    {
        return _randomLoc;
    }

    public Dictionary<MarvelLocation, LocationInfo> GetLocationInfo()
    {
        return _locationsInfo;
    }

    public Dictionary<IPlayer, List<ICard>> GetLocationCards(MarvelLocation loc)
    {
        return _locationsInfo[loc].GetCardsOnLoc();
    }

    public List<ICard> GetLocationCards(MarvelLocation loc, IPlayer player)
    {
        return _locationsInfo[loc].GetCardsOnLoc(player);
    }

    public Dictionary<IPlayer, int> GetLocationScore(MarvelLocation loc)
    {
        return _locationsInfo[loc].GetLocScore();
    }
    public int GetLocationScore(MarvelLocation loc, IPlayer player)
    {
        return _locationsInfo[loc].GetLocScore(player);
    }

    public List<MarvelLocation> OpenedLocation()
    {
        int num = 0;
        List<MarvelLocation> openedLoc = new();
        // foreach(MarvelLocation loc in _locationsInfo.Keys)
        foreach (MarvelLocation loc in _randomLoc)
        {
            if (num < CheckRound())
            {
                openedLoc.Add(loc);
                loc.SetIsOpened(true);
                num += 1;

            }
            else
            {
                break;
            }
        }
        return openedLoc;
    }

    public int GetPlayerEnergy(IPlayer player)
    {
        return _playersInfo[player].GetEnergy();
    }

    public List<ICard> GetPlayableCard(IPlayer player)
    {
        List<ICard> playableCard = new();
        PlayerInfo info = _playersInfo[player];
        List<MarvelCard> listCard = info.GetCards();
        int energy = info.GetEnergy();

        foreach (ICard card in listCard)
        {
            if (card.GetCardCost() <= energy)
            {
                playableCard.Add(card);
            }
        }
        return playableCard;
    }

    public bool IsCardValid(IPlayer player, int cardIndex)
    {
        return GetPlayableCard(player).Contains(GetPlayerCards(player)[cardIndex - 1]);
    }

    public bool PlaceCard(IPlayer player, int cardIndex, int locIndex)
    {
        MarvelCard selectedCard = GetPlayerCards(player)[cardIndex - 1];
        MarvelLocation selectedLoc = _randomLoc[locIndex - 1];
        LocationInfo locInfo = _locationsInfo[selectedLoc];
        locInfo.PlaceCard(player, selectedCard);

        _playersInfo[player].PopCardFromDeck(selectedCard);
        
        





        return true;
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

    // public MarvelLocation ConvertIndexToLoc(int locIndex)
    // {

    // }

    public bool IsCardFullInLocation(IPlayer player, int locIndex)
    {
        MarvelLocation selectedLoc = _randomLoc[locIndex - 1];
        if (locIndex < 1 || locIndex > _randomLoc.Count)
        {
            return false;
        }

        if (_locationsInfo[selectedLoc].GetCardsOnLoc(player).Count > 3)
        {
            return false;
        }
        return true;
    }

    // public IPlayer GetWinner(Ilocation location)
    // {

    // }
    // public List<ICard> ListAllCardFromPlayer(IPlayer player){

    // }

    // public bool AddPlayerDeck(IPlayer player, ICard card){
    //     PlayerInfo playerInfo = new PlayerInfo();
    //     playerInfo.AddCardToDeck(new MarvelCard(card));

    //     return true;
    // }
};

// public bool AddNewCardToLocation(Ilocation location, IPlayer player, ICard card)
// {
//     return true;
// }


// public bool SetGameMode(GameMode gameMode)
// {
//     return true;
// }


