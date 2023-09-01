using System;
using MarvelSnapProject;

class Program{
    public static void Main(){
        Console.WriteLine("==== Welcome To Marvel Snap ==== \n");

        // Add Player
        Console.Write("Input First Player's Name : ");
        string? name1 = Console.ReadLine();
        MarvelPlayer player1 = new MarvelPlayer(name1, 111);
        GameController.AddNewPlayer(player1);
        // Console.WriteLine(player1.GetPlayerName());
        // Console.WriteLine(player1.GetPlayerID());

        Console.Write("Input Second Player's Name : ");
        string? name2 = Console.ReadLine();
        MarvelPlayer player2 = new MarvelPlayer(name2, 112);
        GameController.AddNewPlayer(player2);
        // Console.WriteLine(player2.GetPlayerName());
        // Console.WriteLine(player2.GetPlayerID());


        

        
    }
}