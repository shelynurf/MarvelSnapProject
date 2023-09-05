using System;
using MarvelSnapProject;
using System.Runtime.Serialization.Json;
using System.Text;

public partial class Program
{

    public static void Main()
    {
        GameController game = new();

        Console.Clear();
        Console.WriteLine("==== Welcome To Marvel Snap ==== \n");

        // Add Player
        Iplayer player1, player2;
        Console.Write("Input First Player's Name : ");
        string? name1 = Console.ReadLine();
        name1 = char.ToUpper(name1[0]) + name1.Substring(1);
        player1 = new MarvelPlayer(name1, 111);
        game.AddNewPlayer(player1);


        do
        {

            Console.Write("Input Second Player's Name : ");
            string? name2 = Console.ReadLine();
            name2 = char.ToUpper(name2[0]) + name2.Substring(1);
            player2 = new MarvelPlayer(name2, 112);
        } while (player1.GetPlayerName() == player2.GetPlayerName());
        game.AddNewPlayer(player2);


        // List All Players
        var players = game.ListAllPlayer();
        Console.WriteLine("\nPlayer's ID \t Player's Name");
        foreach (var player in players)
        {
            Console.WriteLine(player.GetPlayerID() + "\t\t\t" + player.GetPlayerName());
        }

        // Console.WriteLine($"\nWelcome {player1.GetPlayerName()} and {player2.GetPlayerName()} ! \nLets Play !! \n");


        //remove player
        // game.RemovePlayer(player1);
        // players = game.ListAllPlayer();
        // foreach (var player in players){
        // Console.WriteLine(player.GetPlayerID() + "\t\t\t" + player.GetPlayerName());
        // }

        do
        {
            Console.WriteLine("\nPress (y) to start the Game");
        }
        while (Console.ReadKey().Key != ConsoleKey.Y);

        Console.Clear();

        // var allCards = game.GetAllCards();
        // foreach (var card in allCards){
        //     Console.WriteLine(card.GetCardName());
        // }

        // Serialization
        List<MarvelCard> cards = new List<MarvelCard>();
        cards.Add(new("Hawkeye", 1, 1, CardType.OnReveal, CardSkill.Hawkeye));
        cards.Add(new("Misty Knight", 1, 2, CardType.Normal, CardSkill.MistyKnight));
        cards.Add(new("Abomination", 5, 9, CardType.Normal, CardSkill.Abomination));
        cards.Add(new("Cyclops", 3, 4, CardType.Normal, CardSkill.Cyclops));
        cards.Add(new("Hulk", 6, 12, CardType.Normal, CardSkill.Hulk));
        cards.Add(new("Iron Man", 5, 0, CardType.OnGoing, CardSkill.IronMan));
        cards.Add(new("Medusa", 2, 2, CardType.OnReveal, CardSkill.Medusa));
        cards.Add(new("Punisher", 3, 2, CardType.OnGoing, CardSkill.Punisher));
        cards.Add(new("Quicksilver", 1, 2, CardType.Normal, CardSkill.Quicksilver));
        cards.Add(new("Sentinel", 2, 3, CardType.OnReveal, CardSkill.Sentinel));
        cards.Add(new("Shocker", 2, 3, CardType.Normal, CardSkill.Shocker));
        cards.Add(new("Star-Lord", 2, 2, CardType.OnReveal, CardSkill.StarLord));
        cards.Add(new("The Thing", 4, 6, CardType.Normal, CardSkill.TheThing));
        cards.Add(new("Jessica Jones", 4, 4, CardType.OnReveal, CardSkill.JessicaJones));
        cards.Add(new("Ant Man", 1, 1, CardType.OnGoing, CardSkill.AntMan));
        cards.Add(new("Squirrel", 1, 1, CardType.Normal, CardSkill.Squirrel));

        List<MarvelLocation> locations = new List<MarvelLocation>{
            new("Necrosha", LocationSkill.Necrosha),
            new("Central Park", LocationSkill.CentralPark),
            new("Negative Zone", LocationSkill.NegativeZone),
            new("The Superflow", LocationSkill.TheSuperflow),
            new("Asgard", LocationSkill.Asgard),
            new("Lemuria", LocationSkill.Lemuria),
            new("The Big House", LocationSkill.TheBigHouse),
            new("Subterranea", LocationSkill.Subterranea)
        };

        

        DataContractJsonSerializer serCard = new DataContractJsonSerializer(typeof(List<MarvelCard>));

        FileStream streamCard = new FileStream(@".\Component\Database\cards.json", FileMode.Create);
        using (var writerCard = JsonReaderWriterFactory.CreateJsonWriter(streamCard, Encoding.UTF8, true, true, "   "))
        {
            serCard.WriteObject(writerCard, cards);

        }

        // List<MarvelLocation> locations = new List<MarvelLocation>();
        // locations.Add(new("Necrosha", LocationSkill.Necrosha));

        DataContractJsonSerializer serLoc = new DataContractJsonSerializer(typeof(List<MarvelLocation>));

        FileStream streamLoc = new FileStream(@".\Component\Database\locations.json", FileMode.Create);
        using (var writerLoc = JsonReaderWriterFactory.CreateJsonWriter(streamLoc, Encoding.UTF8, true, true, "   "))
        {
            serLoc.WriteObject(writerLoc, locations);

        }

        // Deserialized
        List<MarvelCard> importCards;
        using (FileStream streamCard2 = new FileStream(@".\Component\Database\cards.json", FileMode.OpenOrCreate))
        {
            importCards = (List<MarvelCard>)serCard.ReadObject(streamCard2);
        }

        List<MarvelLocation> importLocations;
        using (FileStream streamLoc2 = new FileStream(@".\Component\Database\locations.json", FileMode.OpenOrCreate))
        {
            importLocations = (List<MarvelLocation>)serLoc.ReadObject(streamLoc2);
        }

        // Start the game
        

        Console.WriteLine("round " + game.CheckRound());
        game.NextRound();
        Console.WriteLine(game.CheckRound());

        Random random = new Random();
        





    }
}