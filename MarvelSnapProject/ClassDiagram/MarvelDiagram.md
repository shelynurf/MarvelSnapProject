```
classDiagram
    ICard <|.. MarvelCard
    ILocation <|.. MarvelLocation
    IPlayer <|.. MarvelPlayer
    GameController "1" *-- "2" MarvelPlayer
    GameController "1" *-- "3" MarvelLocation
    GameController "1" *-- "n" MarvelCard
    GameController "1" *-- "2" PlayerInfo
    GameController "1" *-- "n" SkillCard
    GameController "1" *-- "n" MarvelSerialized
    GameController "1" *-- "n" SkillLocation
    LocationInfo "1" *-- "2" PlayerInfo
    MarvelCard "1" o-- "1" ActionDelegate
    GameController -- GameStatus
    MarvelCard -- CardSkill
    MarvelCard -- CardType
    MarvelLocation -- LocationSkill
    PlayerInfo -- PlayerStatus






    class GameController{
        - int _round
        - Dictionary~IPlayer.PlayerInfo~ _playersInfo
        - Dictionary~MarvelLocation.LocationInfo~ _locationsInfo
        - List~Ilocation~ _locations
        - List~Ilocation~ _cards
        - GameStatus _gameStatus
        - MarvelSerialized _marvelSer
        - List~MarvelCard~ _allCards
        - List~MarvelLocation~ _allLocations
        - Random _random
        - List~MarvelLocation~ _randomLoc
        - Dictionary~CardSkill.ActionDelegate~ _skillCards
        - string _winner;
        + AddNewPlayer(IPlayer) bool
        + RemovePlayer(IPlayer) bool
        + ListAllPlayer() IEnumerable~IPlayer~
        + CheckRound() int
        + GetGameStatus() GameStatus
        + NextRound() bool
        + GetAllCards() List~MarvelCard~
        + GetAllLocations() List~MarvelLocation~
        + SetPlayerDeck(IPlayer, List~int~) bool
        + GetPlayerDeck(IPlayer) List~MarvelCard~
        + GenerateCard(IPlayer) bool
        + GenerateCard(IPlayer, MarvelCard) bool
        + GetPlayerCards(IPlayer) List~MarvelCard~
        + GenerateLocation() bool
        + GetLocations() List~MarvelLocation~
        + GetLocationInfo() Dictionary~MarvelLocation.LocationInfo~
        + GetLocationCards(MarvelLocationoc) Dictionary~IPlayer.List~ICard~~
        + GetLocationCards(MarvelLocation, IPlayer) List~ICard~
        + CheckCardLocation(IPlayer, ICard) MarvelLocation
        + GetLocationScore(MarvelLocation) Dictionary~IPlayer.int~
        + GetLocationScore(MarvelLocation, IPlayer) int
        + ApplyOnGoingLocs() bool
        + GetLocationWinner() Dictionary~MarvelLocation.IPlayer~
        + GetLocationWinner(MarvelLocation) IPlayer
        + GetTotalScore() Dictionary~IPlayer.int~
        + SyncTotalWin() bool
        + GetTotalWin() Dictionary~IPlayer.int~
        + GetWinner() string
        + OpenedLocation() List~MarvelLocation~
        + GetPlayerEnergy(IPlayer) int
        + GetPlayableCard(IPlayer) List~ICard~
        + IsCardValid(IPlayer, int) bool
        + PlaceCard(IPlayer, int carndex, int) bool
        + IsCardFullInLocation(IPlayer, int) bool
    }

    class ActionDelegate{
        <<delegate>>
        + ActionDelegate(GameController, IPlayer) bool
    }

    class ICard{
        + GetCardName() string
        + GetCardCost() int
        + GetCardPower() int
        + GetCardDescription() string
        + SetCardName(string) bool
        + SetCardCost(int) bool
        + SetCardPower(int) bool

    }

    class MarvelCard{
        - string _cardName
        - int _cardCost
        - int _cardPower
        - CardType _cardType
        - CardSkill _cardSkill
        - string _cardDescription
        - ActionDelegate _action        
        - bool _isAffected
        + GetCardType() CardType
        + GetCardSkill() CardSkill
        + IsAffected() bool
        + SetAffected(bool) bool
        + Copy() MarvelCard
        + Action(ActionDelegate, GameController, IPlayer, MarvelLocation) bool
    }

    class SkillCard{
        + SkillDefault(GameController, IPlayer, MarvelLocation) bool
        + SkillMedusa(GameController, IPlayer, MarvelLocation) bool
        + SkillSentinel(GameController, IPlayer, MarvelLocation) bool
        + SkillBlackPanther(GameController, IPlayer, MarvelLocation) bool


    }

    class MarvelSerialized{
        - DataContractJsonSerializer _serCard
        - DataContractJsonSerializer _serLoc
        + ImportCards() List~MarvelCard~
        + ImportLocations() List~MarvelLocation~

    }

    class ILocation{
        + GetLocationName() string
        + SetLocationName(string) bool

    }

    class LocationInfo{
        - Dictionary~IPlayer.int~ _scoreLoc
        - Dictionary~IPlayer.List~ICard~~ _cardsLoc
        - Dictionary~IPlayer.PlayerInfo~ _playerLocInfo
        + InitLocPlayer(IEnumerable~IPlayer~) bool
        + GetCardsOnLoc() Dictionary~IPlayer.List~ICard~~
        + GetCardsOnLoc(IPlayer) List~ICard~
        + GetLocScore() Dictionary~IPlayer.int~
        + GetLocScore(IPlayer) int
        + SetLocScore(IPlayer, int) bool
        + AddScore(IPlayer, int) bool
        + PlaceCard(IPlayer, ICard) bool
        + CalculateScore(IPlayer, ICard) bool
        + GetLocWinner() IPlayer
    }

    class MarvelLocation{
        - string _locationName;
        - bool _isFull;
        - LocationSkill _locSkill
        - string _locDescription
        - bool _isOpened
        + GetLocDescription() string
        + GetSkill() LocationSkill
        + SetIsOpened(bool) bool
        + CheckIsOpened() bool

    }

    class SkillLocation{
        + OnGoingLocs(GameController) bool$
    }

    class IPlayer{
        + GetPlayerName() string
        + GetPlayerID() int
        + SetPlayerName(string) bool
        + SetPlayerID(int) bool


    }

    class MarvelPlayer{
        - string _playerName
        - int _playerID
    }

    class PlayerInfo{
        - List~MarvelCard~ _deck
        - List~MarvelCard~ _cards
        - int _energy
        - int _maxDeck
        - int _totalWin
        - PlayerStatus _playerStatus
        + GetDeck() List~MarvelCard~
        + GetMaxDeck() int
        + AddCardToDeck(MarvelCard) bool
        + PopCardFromDeck(MarvelCard) bool
        + AddCard(MarvelCard) bool
        + RemoveCard(MarvelCard) bool
        + GetEnergy() int
        + GetCards() List~MarvelCard~
        + IsCardFullInDecK() bool
        + SetEnergy(int) bool
        + AddTotalWin() bool
        + GetTotalWin() int
        + GetPlayerStatus() PlayerStatus
        + SetPlayerStatus(PlayerStatus) bool

    }

    class CardSkill{
        <<enumeration>>
        Default
        IronMan
        Medusa
        Sentinel
        Antmant
        BlackPanther
    }

    class CardType{
        <<enumeration>>
        Normal
        OnReveal
        OnGoing
    }
    class GameStatus{
        <<enumeration>>
        NotStarted
        Running
        Finished
    }

    class LocationSkill{
        <<enumeration>>
        Ruins
        Nidavellir
        CloningVat
        Atlantis
    }

    class PlayerStatus{
        <<enumeration>>
        Win
        Lose
        Draw
    }
    ```