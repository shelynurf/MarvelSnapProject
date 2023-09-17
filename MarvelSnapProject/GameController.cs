
using System.Linq;
using NLog;


namespace MarvelSnapProject;

public class GameController
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    private int _round = 0;
    // private List<int> _rounds = new();
    private Dictionary<IPlayer, PlayerInfo> _playersInfo = new();
    private Dictionary<MarvelLocation, LocationInfo> _locationsInfo = new();
    private List<ILocation> _locations = new();
    private List<MarvelCard> _cards = new();
    // private bool _endTurn = false;
    private GameStatus _gameStatus = GameStatus.NotStarted;
    private MarvelSerialized _marvelSer = new MarvelSerialized();
    private List<MarvelCard> _allCards = new List<MarvelCard>();
    private List<MarvelLocation> _allLocations = new();
    private Random _random = new Random();
    private List<MarvelLocation> _randomLoc = new();
    // private Dictionary<CardSkill, OnRevealDelegate> _skillOnReveal = new();
    // private Dictionary<CardSkill, OnGoingDelegate> _skillOnGoing = new();
    private Dictionary<CardSkill, ActionDelegate> _skill = new();
    private Dictionary<LocationSkill, LocationDelegate> _skillLocations = new();

    private string _winner;

    // private IPlayer _turn = new();

    /// <summary>
    /// Add instance of player to join the game
    /// </summary>
    /// <param name="player">player's instance</param>
    /// <returns>True if success</returns>
    public bool AddNewPlayer(IPlayer player)
    {
        if (! (_playersInfo.Count > 2))
        {
            if (!_playersInfo.ContainsKey(player))
            {
                foreach (IPlayer regPlayer in _playersInfo.Keys)
                {

                    if (regPlayer.GetPlayerName() == player.GetPlayerName() || regPlayer.GetPlayerID() == player.GetPlayerID())
                    {
                        logger.Warn("Failed Add Player because player already registered");
                        return false;
                    }
                }
                PlayerInfo playerInfo = new();
                _playersInfo.Add(player, playerInfo);
                logger.Info("Success Add Player");
                return true;
            }
        }
        else logger.Warn("Failed Add Player more than 2");
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
        if (_playersInfo.ContainsKey(player))
        {
            _playersInfo.Remove(player);
            return true;
        }
        return false;

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

    // public bool GetEndTurn()
    // {
    //     return _endTurn;
    // }

    // public IPlayer GetCurrentPlayer()
    // {
    //     // List<IPlayer> players = ListAllPlayer().ToList();
    //     List<IPlayer> players = _playersInfo.Keys.ToList();
    //     IPlayer playersTurn = null;
    //     foreach (var player in players)
    //     {
    //         int index = players.IndexOf(player);           
    //         if (_endTurn == false)
    //         {
    //             playersTurn = player;
    //         }
    //         else 
    //         {
    //             if (index == 0)
    //             {
    //                 playersTurn = players[index + 1];
    //             }
    //             if (index ==1)
    //             {
    //                 playersTurn = players[index - 1];
    //             }
                
    //         }

    //     }
    //     return playersTurn; 
    // }


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
            // _rounds.Add(_round);


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
                // _rounds.Add(_round);
            }
        }

        foreach (PlayerInfo info in _playersInfo.Values)
        {
            info.SetEnergy(_round);
        }
        return true;
    }


    /// <summary>
    /// Return List all card inside card database
    /// </summary>
    /// <returns></returns>
    public List<MarvelCard> GetAllCards()
    {
        _allCards = _marvelSer.ImportCards();
        return _allCards;
    }

    /// <summary>
    /// Return List all location inside Location database
    /// </summary>
    /// <returns></returns>

    public List<MarvelLocation> GetAllLocations()
    {
        _allLocations = _marvelSer.ImportLocations();
        return _allLocations;
    }

    /// <summary>
    /// Set 12 card to registered as player's deck.
    /// </summary>
    /// <param name="player">Player who wants to set the deck</param>
    /// <param name="listCardIndex">Card index (based on card database) that wanna be registered as player deck</param>
    /// <returns>Return true if success</returns>

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
        //     MarvelCard card = _allCards[index].Copy();
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

    /// <summary>
    /// Return List of card inside player's deck
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>

    public List<MarvelCard> GetPlayerDeck(IPlayer player)
    {
        return _playersInfo[player].GetDeck();
    }

    /// <summary>
    /// Generate cards in hand of each round to player
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
            if (!GetPlayerCards(player).Contains(card))
            {
                List<MarvelCard> placedCards = new();
                foreach (var loc in _randomLoc)
                {
                    placedCards.AddRange(GetLocationCards(loc, player));
                }
                if (!placedCards.Contains(card))
                {
                    info.AddCard(card);
                }
                else
                {
                    GenerateCard(player);
                }
            }
            // info.AddCard(card);
            CardSkill skill = card.GetCardSkill();

            // OnRevealDelegate skilIronMan = SkillCards.SkillIronMan;
            // OnRevealDelegate actionOnReveal = null;
            // OnGoingDelegate actionOngoing = null;
            // OnRevealDelegate skillSentinel = AbilityOnReveal.SkillSentinel;
            // OnGoingDelegate skillIronMan = AbilityOnGoing.SkillIronMan;
            // OnRevealDelegate skillMedusa = AbilityOnReveal.SkillMedusa;
            // OnRevealDelegate skillBlackPanther = AbilityOnReveal.SkillBlackPanther;
            // OnGoingDelegate skillDefault = AbilityOnGoing.SkillDefault;

   
            ActionDelegate action = null;
            ActionDelegate skillSentinel = SkillCards.SkillSentinel;
            ActionDelegate skillIronMan = SkillCards.SkillIronMan;
            ActionDelegate skillMedusa = SkillCards.SkillMedusa;
            ActionDelegate skillBlackPanther = SkillCards.SkillBlackPanther;
            ActionDelegate skillAntMan = SkillCards.SkillAntMan;
            ActionDelegate skillDefault = SkillCards.SkillDefault;


            //     switch (skill) {
            //     case CardSkill.Sentinel:
            //         card.Action(skillSentinel, this, player);
            //         break;
            //     default:
            //         card.Action(skillDefault, this, player);
            //         break;
            // }

            // switch (skill)
            // {
            //     case CardSkill.IronMan:
            //         actionOngoing = skillIronMan;
            //         break;
            //     case CardSkill.Sentinel:
            //         actionOnReveal = skillSentinel;
            //         break;
            //     case CardSkill.Medusa:
            //         actionOnReveal = skillMedusa;
            //         break;
            //     case CardSkill.BlackPanther:
            //         actionOnReveal = skillBlackPanther;
            //         break;
            //     case CardSkill.Default:
            //         actionOngoing = skillDefault;
            //         break;
            //     default:
            //         actionOngoing = skillDefault;
            //         break;
            // }

            switch (skill)
            {
                case CardSkill.IronMan:
                    action = skillIronMan;
                    break;
                case CardSkill.Sentinel:
                    action = skillSentinel;
                    break;
                case CardSkill.Medusa:
                    action = skillMedusa;
                    break;
                case CardSkill.BlackPanther:
                    action = skillBlackPanther;
                    break;
                case CardSkill.AntMan:
                    action = skillAntMan;
                    break;
                case CardSkill.Default:
                    action = skillDefault;
                    break;
                default:
                    action = skillDefault;
                    break;
            }

            // if (!_skillOnReveal.ContainsKey(skill) && card.GetCardType() == CardType.OnReveal)
            // {
            //     _skillOnReveal.Add(skill, actionOnReveal);
            // }
            // else if (!_skillOnGoing.ContainsKey(skill) && card.GetCardType() == CardType.OnGoing)
            // {
            //     _skillOnGoing.Add(skill, actionOngoing);
            // }
            if (!_skill.ContainsKey(skill))
            {
                _skill.Add(skill, action);
            }



            // if (!GetPlayerCards(player).Contains(card))
            // {

            //     List<MarvelCard> placeCard = new();
            //     foreach (var loc in _randomLoc)
            //     {
            //         placeCard.Concat(GetLocationCards(loc, player)).ToList();
            //     }
            //     if (!placeCard.Contains(card))
            //     {
            //         info.AddCard(card);
            //         return true;
            //     }
            //     // return false;
            // }
            // return false;

        }
        // return false;
        return true;


        // int randomIndex = random.Next(0, deck.Count);
        // MarvelCard card = deck[randomIndex].Copy();
        // return true;
    }

    /// <summary>
    /// Generate specific card to player
    /// </summary>
    /// <param name="player"></param>
    /// <param name="card"></param>
    /// <returns></returns>
    public bool GenerateCard(IPlayer player, MarvelCard card)
    {
        PlayerInfo info = _playersInfo[player];
        info.AddCard(card);
        return true;
    }

    /// <summary>
    /// Return list of card in player's hand
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>

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

            // LocationSkill skill = loc.GetSkill();
            // LocationDelegate action;
            // LocationDelegate skillNidavellir = SkillLocation.SkillNidavellir;
            // LocationDelegate skillCloningVat = SkillLocation.SkillCloningVat;
            // LocationDelegate skillAtlantis = SkillLocation.SkillAtlantis;
            // LocationDelegate skillDefault = SkillLocation.SkillDefault;
            
            // switch (skill)
            // {
            //     case LocationSkill.Ruins :
            //         action = skillDefault;
            //         break;
            //     case LocationSkill.Nidavellir :
            //         action = skillNidavellir;
            //         break;
            //     case LocationSkill.CloningVat :
            //         action = skillCloningVat;
            //         break;
            //     case LocationSkill.Atlantis :
            //         action = skillAtlantis;
            //         break;
            //     default:
            //         action = skillDefault;
            //         break;
            // }

            // if (!_skillLocations.ContainsKey(skill))
            // {
            //     _skillLocations.Add(skill, action);
            // }
        }

        return true;
    }

    /// <summary>
    /// Return list of 3 location that has been generate
    /// </summary>
    /// <returns></returns>
    public List<MarvelLocation> GetLocations()
    {
        return _randomLoc;
    }

    /// <summary>
    /// Return each location and its location info
    /// </summary>
    /// <returns>Dictionary of MarvelLocation and LocationInfo</returns>

    public Dictionary<MarvelLocation, LocationInfo> GetLocationInfo()
    {
        return _locationsInfo;
    }

    /// <summary>
    /// Return each player and his/her cards on location
    /// </summary>
    /// <param name="loc"></param>
    /// <returns>Dictionary of Player and List Marvel Card</returns>
    public Dictionary<IPlayer, List<MarvelCard>> GetLocationCards(MarvelLocation loc)
    {
        return _locationsInfo[loc].GetCardsOnLoc();
    }

    /// <summary>
    /// Return List of card from specific player in specific location
    /// </summary>
    /// <param name="loc"></param>
    /// <param name="player"></param>
    /// <returns>List of MarvelCard</returns>
    public List<MarvelCard> GetLocationCards(MarvelLocation loc, IPlayer player)
    {
        return _locationsInfo[loc].GetCardsOnLoc(player);
    }
    /// <summary>
    /// Check the location of a player card
    /// </summary>
    /// <param name="player"></param>
    /// <param name="card"></param>
    /// <returns>Marvel Location</returns>

    public MarvelLocation CheckCardLocation(IPlayer player, MarvelCard card)
    {
        // MarvelLocation loc = null;

        // foreach (var kvp in _locationsInfo)
        // {
        //     if (kvp.Value.GetCardsOnLoc(player).Contains(card))
        //     {
        //         loc = kvp.Key;
        //         break;
        //     }
        // }

        MarvelLocation loc = _locationsInfo.FirstOrDefault(x => x.Value.GetCardsOnLoc(player).Contains(card)).Key;

        return loc;
    }

    /// <summary>
    /// Return each player and his/her score on specific location
    /// </summary>
    /// <param name="loc"></param>
    /// <returns>Dictionary of Player and integer score</returns>
    public Dictionary<IPlayer, int> GetLocationScore(MarvelLocation loc)
    {
        return _locationsInfo[loc].GetLocScore();
    }

    /// <summary>
    /// return integer of score from specific player in specific location
    /// </summary>
    /// <param name="loc"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public int GetLocationScore(MarvelLocation loc, IPlayer player)
    {
        return _locationsInfo[loc].GetLocScore(player);
    }

    /// <summary>
    /// Set player score on location using specific value
    /// </summary>
    /// <param name="loc"></param>
    /// <param name="player"></param>
    /// <param name="newScore"></param>
    /// <returns></returns>

    public bool SetLocationScore(MarvelLocation loc, IPlayer player, int newScore)
    {
        _locationsInfo[loc].SetLocScore(player, newScore);
        return true;
    }

    /// <summary>
    /// Apply action skill of location along the game
    /// </summary>
    /// <returns></returns>

    public bool ApplyOnGoingLocs()
    {
        SkillLocation.OnGoingLocs(this);
        return true;
        // foreach (MarvelLocation loc in _randomLoc)
        // {
        //     LocationDelegate action = _skillLocations[loc.GetSkill()];
        //     loc.Action(action, this);
        // }
        // return true;
    }

    /// <summary>
    /// Return each location an its winner
    /// </summary>
    /// <returns></returns>
    public Dictionary<MarvelLocation, IPlayer> GetLocationWinner()
    {
        Dictionary<MarvelLocation, IPlayer> locWinner = new();
        foreach (var kvp in _locationsInfo)
        {

            IPlayer winner = _locationsInfo[kvp.Key].GetLocWinner();
            locWinner.Add(kvp.Key, winner);
        }
        return locWinner;
    }

    /// <summary>
    /// Return winner of specific location
    /// </summary>
    /// <param name="loc"></param>
    /// <returns></returns>

    public IPlayer GetLocationWinner(MarvelLocation loc)
    {
        return _locationsInfo[loc].GetLocWinner();
    }

    /// <summary>
    /// return total score on all location from each player
    /// </summary>
    /// <returns></returns>
    public Dictionary<IPlayer, int> GetTotalScore()
    {
        Dictionary<IPlayer, int> totalScore = new();
        foreach (var kvpPlayer in _playersInfo)
        {
            IPlayer player = kvpPlayer.Key;
            int playerScore = 0;
            foreach (var kvpLoc in _locationsInfo)
            {
                LocationInfo locInfo = kvpLoc.Value;
                playerScore += locInfo.GetLocScore()[player];
            }
            totalScore.Add(player, playerScore);
        }
        return totalScore;
    }

    /// <summary>
    /// Sync data to get total win of each player
    /// </summary>
    /// <returns></returns>

    public bool SyncTotalWin()
    {
        foreach (var kvp in GetLocationWinner())
        {
            foreach (IPlayer player in ListAllPlayer())
            {
                if (kvp.Value == player)
                {
                    _playersInfo[player].AddTotalWin();
                }
            }
        }
        return true;
    }

    /// <summary>
    /// return total win of each player
    /// </summary>
    /// <returns></returns>

    public Dictionary<IPlayer, int> GetTotalWin()
    {
        Dictionary<IPlayer, int> totalWinPlayers = new();
        foreach (var kvp in _playersInfo)
        {
            IPlayer player = kvp.Key;
            PlayerInfo info = kvp.Value;
            int win = info.GetTotalWin();
            totalWinPlayers.Add(player, win);
        }
        return totalWinPlayers;
    }

    /// <summary>
    /// return string of Winner name, or Draw
    /// </summary>
    /// <returns></returns>

    public string GetWinner()
    {
        int higestWin = 0;
        int higestTotalScore = 0;
        string winner = null;
        foreach (var kvp in GetTotalWin())
        {
            IPlayer player = kvp.Key;
            int win = kvp.Value;
            if (win > higestWin)
            {
                higestWin = win;
                winner = player.GetPlayerName();
            }
            else if (win == higestWin)
            {
                if (GetTotalScore()[player] > higestTotalScore)
                {
                    higestTotalScore = GetTotalScore()[player];
                    winner = player.GetPlayerName();
                }
                else if (GetTotalScore()[player] == higestTotalScore)
                {
                    winner = "DRAW";
                }
            }
        }
        return winner;
    }

    /// <summary>
    /// Return List of location that has been opened on each round
    /// </summary>
    /// <returns></returns>

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


    /// <summary>
    /// return integer of current player energy
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>

    public int GetPlayerEnergy(IPlayer player)
    {
        return _playersInfo[player].GetEnergy();
    }

    /// <summary>
    /// return list card that valid to be place on each round
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>

    public List<MarvelCard> GetPlayableCard(IPlayer player)
    {
        List<MarvelCard> playableCard = new();
        PlayerInfo info = _playersInfo[player];
        List<MarvelCard> listCard = info.GetCards();
        int energy = info.GetEnergy();

        foreach (MarvelCard card in listCard)
        {
            if (card.GetCardCost() <= energy)
            {
                playableCard.Add(card);
            }
        }
        return playableCard;
    }

    /// <summary>
    /// check if the card is valid to place or not
    /// </summary>
    /// <param name="player"></param>
    /// <param name="cardIndex"></param>
    /// <returns>Return true if card is valid to place</returns>

    public bool IsCardValid(IPlayer player, int cardIndex)
    {
        return GetPlayableCard(player).Contains(GetPlayerCards(player)[cardIndex - 1]);
    }

    /// <summary>
    /// return true if card is successfully placed
    /// </summary>
    /// <param name="player"></param>
    /// <param name="cardIndex"></param>
    /// <param name="locIndex"></param>
    /// <returns></returns>

    public bool PlaceCard(IPlayer player, int cardIndex, int locIndex)
    {
        MarvelCard selectedCard = GetPlayerCards(player)[cardIndex - 1];
        CardSkill skill = selectedCard.GetCardSkill();
        MarvelLocation selectedLoc = OpenedLocation()[locIndex - 1];
        LocationInfo locInfo = _locationsInfo[selectedLoc];
        PlayerInfo info = _playersInfo[player];
        int currentEnergy = info.GetEnergy();
        locInfo.PlaceCard(player, selectedCard);

        info.PopCardFromDeck(selectedCard);
        info.RemoveCard(selectedCard);
        info.SetEnergy(currentEnergy - selectedCard.GetCardCost());
        // if (selectedCard.GetCardType() == CardType.OnReveal)
        // {
        //     selectedCard.Action(_skillOnReveal[skill], this, player, selectedLoc);
        // }
        // else if (selectedCard.GetCardType() == CardType.OnGoing)
        // {
        //     selectedCard.Action(_skillOnGoing[skill], this);
        // }
        selectedCard.Action(_skill[skill], this, player, selectedLoc);
        ApplyOnGoingActionCard();
        return true;
    }

    /// <summary>
    /// Apply skill of OnGoing card on every round
    /// </summary>
    /// <returns></returns>
    public bool ApplyOnGoingActionCard()
    {
        foreach (var loc in _randomLoc)
        {
            foreach (var player in ListAllPlayer())
            {
                List<MarvelCard> onGoingCards = GetLocationCards(loc, player).FindAll(x => x.GetCardType() == CardType.OnGoing);
                foreach (var card in onGoingCards)
                {
                    var skill = card.GetCardSkill();
                    card.Action(_skill[skill], this, player, loc);
                }
            }
        }
        return true;
    }

    /// <summary>
    /// check whether the location is full or not, maksimum card on location is 4 card
    /// </summary>
    /// <param name="player"></param>
    /// <param name="locIndex"></param>
    /// <returns></returns>
    public bool IsCardFullInLocation(IPlayer player, int locIndex)
    {
        int maxCardOnLoc = 4;

        if (locIndex < 1 || locIndex > _randomLoc.Count)
        {
            return false;
        }
        MarvelLocation selectedLoc = _randomLoc[locIndex - 1];
        if (_locationsInfo[selectedLoc].GetCardsOnLoc(player).Count == maxCardOnLoc)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
};
