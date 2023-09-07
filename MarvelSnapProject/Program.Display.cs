using MarvelSnapProject;

public partial class Program
{
    
    private Dictionary<IPlayer, List<int>> _playerDeck = new();

    public static void DisplayLocation(GameController game, IPlayer player){
        // game.GetAllLocations();
        List<MarvelLocation> locations = game.GetLocations();
        List<MarvelLocation> openedLoc = game.OpenedLocation();

        Console.WriteLine("Round : " + game.CheckRound());
        Console.WriteLine($"Players Turn : {player.GetPlayerName().ToUpper()}");
        Console.WriteLine("");
        foreach(MarvelLocation loc in locations)
        {
            if (openedLoc.Contains(loc))
            {
                Console.WriteLine($"Location {openedLoc.IndexOf(loc) + 1} : {loc.GetLocationName()} ({loc.GetLocDescription()})");
                DisplayCardLock(game, loc);
            }
            else{
                Console.WriteLine($"Location {openedLoc.IndexOf(loc) + 1}");
                DisplayCardLock(game, loc);
            }
        }

    }

    public static void DisplayCardLock(GameController game, MarvelLocation loc){
        Dictionary<IPlayer, List<ICard>> playersCard = game.GetLocationCards(loc);
        foreach (var kvp in playersCard)
        {
            Console.Write($"({game.GetLocationScore(loc, kvp.Key)}) \t {kvp.Key.GetPlayerName()}'s Cards : ");
            foreach (var card in kvp.Value)
            {
                Console.Write($"{card.GetCardName()}");
            }
            Console.WriteLine("");
        }
    }
    public static void DisplayPlayerCards(IPlayer player, GameController game)
    {
        List<ICard> playerCards = game.GetPlayerCards(player);
        Console.WriteLine($"YOUR ENERGY : {game.GetPlayerEnergy(player)}");
        Console.WriteLine("CARDS :");
        Console.WriteLine("INDEX \t CARD NAME \t\t COST \t POWER \t DESCRIPTION");
        foreach(var card in playerCards)
        {
            Console.WriteLine($"{playerCards.IndexOf(card) + 1} \t {card.GetCardName()} \t\t {card.GetCardCost()} \t {card.GetCardPower()} \t {card.GetCardDescription()}");
        }
       

    }
}