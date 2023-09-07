﻿using System;
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
        string? name1, name2;
        IPlayer player1, player2;
        do
        {
            Console.Write("Input First Player's Name : ");
            name1 = Console.ReadLine();
            name1 = char.ToUpper(name1[0]) + name1.Substring(1);
            player1 = new MarvelPlayer(name1, 111);
        } while (name1 == "" || !game.AddNewPlayer(player1));
        game.AddNewPlayer(player1);


        do
        {

            Console.Write("Input Second Player's Name : ");
            name2 = Console.ReadLine();
            name2 = char.ToUpper(name2[0]) + name2.Substring(1);
            player2 = new MarvelPlayer(name2, 112);
        }
        while (name2 == "" || !game.AddNewPlayer(player2));
        game.AddNewPlayer(player2);


        // List All Players
        // var players = game.ListAllPlayer();
        // Console.WriteLine("\nPlayer's ID \t Player's Name");
        // foreach (var player in players)
        // {
        //     Console.WriteLine(player.GetPlayerID() + "\t\t\t" + player.GetPlayerName());
        // }

        Console.WriteLine($"\nWelcome {player1.GetPlayerName()} and {player2.GetPlayerName()} ! \nLets Play !! \n");

        // Console.WriteLine("round: " + game.CheckRound());
        // Console.WriteLine("game status : " + game.GetGameStatus());

        // remove player
        // game.RemovePlayer(player1);
        // players = game.ListAllPlayer();
        // foreach (var player in players){
        // Console.WriteLine(player.GetPlayerID() + "\t\t\t" + player.GetPlayerName());
        // }

        // game.NextRound();
        // Console.WriteLine("round: " + game.CheckRound());
        // Console.WriteLine("game status : " + game.GetGameStatus());



        do
        {
            Console.WriteLine("\nPress Enter to start the Game");
        }
        while (Console.ReadKey().Key != ConsoleKey.Enter);


        Console.Clear();
        game.NextRound();
        var allCards = game.GetAllCards();
        game.GetAllLocations();
        game.GenerateLocation();
        List<int> deck1 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        List<int> deck2 = new List<int>() { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        while (game.GetGameStatus() == GameStatus.Running)
        {
            var deckPlayer1 = game.SetPlayerDeck(player1, deck1);
            var deckPlayer2 = game.SetPlayerDeck(player2, deck2);
            game.GenerateCard(player1);
            game.GenerateCard(player2);
            game.GetAllLocations();
            // var locations = game.GenerateLocation();

            foreach (IPlayer player in game.ListAllPlayer())
            {
                bool placeAgain = true;
                while (placeAgain)
                {
                    DisplayLocation(game, player);
                    Console.WriteLine("");
                    DisplayPlayerCards(player, game);
                    Console.ReadLine();

                }
            }
            

        }

        
        // Console.WriteLine(allCards.Count);
        // Console.WriteLine("Index \t Card Name \t\t Cost \t Power \t Description");
        
        // foreach (MarvelCard card in allCards)
        // {
        //     if (card.GetCardName().Length < 5)
        //     {
        //         Console.WriteLine($"{allCards.IndexOf(card)}\t {card.GetCardName()} \t\t\t {card.GetCardCost()} \t {card.GetCardPower()} \t {card.GetCardDescription()}");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"{allCards.IndexOf(card)}\t {card.GetCardName()} \t\t {card.GetCardCost()} \t {card.GetCardPower()} \t {card.GetCardDescription()}");
        //     }
        // }

        // foreach (var card in allCards)
        // {
        //     Console.WriteLine(card.GetCardName() + ", ");
        // }

        // for (int i = 0; i < allCards.Count; i++){
        //     Console.WriteLine($"{i + 1}\t {allCards[i].GetCardName()} - {allCards[i].GetCardCost()} - {allCards[i].GetCardPower()} - {allCards[i].GetCardDescription()}");
        // }

        // Declare Player Deck
        

        // Locations
        // Console.Clear();
        // var locations = game.GenerateLocation();
        // foreach (var location in locations)
        // {   Console.Write($"Location \t: {locations.IndexOf(location)} {location.GetLocationName()}");
            
        // }


// var allCards = game.GetAllCards();

        var listCard1 = game.GetPlayerDeck(player1);
        Console.Write($"\n{player1.GetPlayerName()}'s Deck : ");
        foreach (var card in listCard1)
        {
            Console.Write(card.GetCardName() + ", ");
        }

        var listCard2 = game.GetPlayerDeck(player2);
        Console.Write($"\n{player2.GetPlayerName()}'s Deck : ");
        foreach (var card in listCard2)
        {
            Console.Write(card.GetCardName() + ", ");
        }

        // Generate Card
        game.NextRound();
        Console.WriteLine("\n");
        Console.WriteLine("Round : " + game.CheckRound());
        Console.WriteLine("\n");
        foreach (IPlayer player in game.ListAllPlayer())
        {
            game.GenerateCard(player);
            List<ICard> cardPlayer = game.GetPlayerCards(player);
            Console.Write($"{player.GetPlayerName()}'s card : ");
            foreach (MarvelCard card in cardPlayer)
            {
                Console.Write(card.GetCardName() + ", ");
            }
            Console.WriteLine("\n");
        }

        // game.GenerateCard(player1);
        // List<ICard> cardPlayer1 = game.GetPlayerCards(player1);
        // Console.Write($"{player1.GetPlayerName()}'s card : ");
        // foreach (MarvelCard card in cardPlayer1){
        //     Console.Write(card.GetCardName() + ", ");
        // }

        // game.GenerateCard(player2);
        // List<ICard> cardPlayer2 = game.GetPlayerCards(player2);
        // Console.Write($"\n{player2.GetPlayerName()}'s card : ");
        // foreach (MarvelCard card in cardPlayer2){
        //     Console.Write(card.GetCardName() + ", ");
        // }

        game.NextRound();
        Console.WriteLine("\n");
        Console.WriteLine("Round : " + game.CheckRound());
        Console.WriteLine("\n");
        foreach (IPlayer player in game.ListAllPlayer())
        {
            game.GenerateCard(player);
            List<ICard> cardPlayer = game.GetPlayerCards(player);
            Console.Write($"{player.GetPlayerName()}'s card : ");
            foreach (MarvelCard card in cardPlayer)
            {
                Console.Write(card.GetCardName() + ", ");
            }
            Console.WriteLine("\n");
        }









    }
}