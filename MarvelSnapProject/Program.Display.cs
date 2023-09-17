using MarvelSnapProject;

public partial class Program
{

    private Dictionary<IPlayer, List<int>> _playerDeck = new();

    public static void DisplayLocation(GameController game, IPlayer player)
    {
        // game.GetAllLocations();
        List<MarvelLocation> locations = game.GetLocations();
        List<MarvelLocation> openedLoc = game.OpenedLocation();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Round : " + game.CheckRound());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Players Turn : {player.GetPlayerName().ToUpper()}");
        Console.ResetColor();
        Console.WriteLine("");
        foreach (MarvelLocation loc in openedLoc)
        {
            if (openedLoc.Contains(loc))
            {
                Console.WriteLine($"Location {openedLoc.IndexOf(loc) + 1} : {loc.GetLocationName()} ({loc.GetLocDescription()})");
                DisplayCardLock(game, loc);
            }
            else
            {
                Console.WriteLine($"Location {openedLoc.IndexOf(loc) + 1} : {loc.GetLocationName()} ({loc.GetLocDescription()})");
                DisplayCardLock(game, loc);
            }
            Console.WriteLine("");
        }

    }

    public static void DisplayCardLock(GameController game, MarvelLocation loc)
    {
        Dictionary<IPlayer, List<MarvelCard>> playersCard = game.GetLocationCards(loc);
        foreach (var kvp in playersCard)
        {
            Console.Write($"({game.GetLocationScore(loc, kvp.Key)}) \t {kvp.Key.GetPlayerName()}'s Cards : ");
            foreach (MarvelCard card in kvp.Value)
            {
                if (kvp.Value.IndexOf(card) != kvp.Value.Count - 1)
                {
                    Console.Write($"{card.GetCardName()}, ");
                }
                else {
                    Console.Write($"{card.GetCardName()}");
                } 
            }
            Console.WriteLine("");
        }
    }
    public static void DisplayPlayerCards(IPlayer player, GameController game)
    {
        List<MarvelCard> playerCards = game.GetPlayerCards(player);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"YOUR ENERGY : {game.GetPlayerEnergy(player)}\n");
        Console.ResetColor();
        Console.WriteLine("INDEX \t CARD NAME \t\t COST \t POWER \t DESCRIPTION");
        foreach (var card in playerCards)
        {
            Console.WriteLine($"{playerCards.IndexOf(card) + 1} \t {card.GetCardName()} \t\t {card.GetCardCost()} \t {card.GetCardPower()} \t {card.GetCardDescription()}");
        }


    }

    public static void DisplayWinner(GameController game)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("========GAMES DONE========");
        Console.ForegroundColor = ConsoleColor.Green;
        if (game.GetWinner() != "DRAW")
        {
            Console.WriteLine($"Congratulation {game.GetWinner()}!! You're The Winner! \n");
        }
        else {
            Console.WriteLine($"Congratulation!! Both of you are tied \n");
        }
        
        Console.ResetColor();
        var locations = game.GetLocations();
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Detail Score : ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.Write("LOCATION \t\t");
        foreach (IPlayer player in game.ListAllPlayer())
        {
            Console.Write($"{player.GetPlayerName().ToUpper()} \t\t");
        }
        Console.WriteLine("WINNER");
        foreach (MarvelLocation loc in locations)
        {
            Console.Write($"Location {locations.IndexOf(loc) + 1} \t\t");
            foreach (var kvp in game.GetLocationScore(loc))
            {
                IPlayer player = kvp.Key;
                int score = kvp.Value;
                Console.Write($"{score} \t\t");
            }
            IPlayer winner = game.GetLocationWinner(loc);
            if (winner != null)
            {
                Console.WriteLine(winner.GetPlayerName());
            }
            else{
                Console.WriteLine("Draw");
            }

        }
        Console.ReadKey();

    }
}