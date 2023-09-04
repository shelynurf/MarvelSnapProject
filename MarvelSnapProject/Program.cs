using System;
using MarvelSnapProject;

class Program{
    public static void Main(){
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

        
        do{
            
            Console.Write("Input Second Player's Name : ");
        string? name2 = Console.ReadLine();
        name2 = char.ToUpper(name2[0]) + name2.Substring(1);
        player2 = new MarvelPlayer(name2, 112);
        } while (player1.GetPlayerName() == player2.GetPlayerName());
        game.AddNewPlayer(player2);


        // List All Players
        var players = game.ListAllPlayer();
        Console.WriteLine("\nPlayer's ID \t Player's Name");
        foreach (var player in players){
        Console.WriteLine(player.GetPlayerID() + "\t\t\t" + player.GetPlayerName());
        }

        Console.WriteLine($"\nWelcome {player1.GetPlayerName()} and {player2.GetPlayerName()} ! \nLets Play !! \n");

        game.RemovePlayer(player2);

         // List All Players
       
        Console.WriteLine("\nPlayer's ID \t Player's Name");
        foreach (var player in players){
        Console.WriteLine(player.GetPlayerID() + "\t\t\t" + player.GetPlayerName());
        }

        Console.WriteLine($"\nWelcome {player1.GetPlayerName()} and {player2.GetPlayerName()} ! \nLets Play !! \n");


        

        
    }
}