
using System.Runtime.Serialization.Json;
using Microsoft.VisualBasic;

namespace MarvelSnapProject.Test;

[TestFixture]
public class Tests
{
    public GameController game;
    [SetUp]
    public void Setup()
    {
        game = new GameController();
    }

    // [Test]
    public void AddPlayer_PlayerAddedSuccessfully()
    {
        //arrange
        MarvelPlayer player1 = new("aziz", 011);
        MarvelPlayer player2 = new("gil", 012);
        bool expected = true;

        //act
        bool result = game.AddNewPlayer(player1);

        // assert
        Assert.AreEqual(expected, result);
    }
    // [Test]
    public void AddPlayer_FalseWhenDuplicatePlayer()
    {
        //arrange
        MarvelPlayer player1 = new("aziz", 011);
        MarvelPlayer player2 = new("aziz", 011);
        bool expected = true;

        //act
        game.AddNewPlayer(player1);
        bool result = game.AddNewPlayer(player2);

        // assert
        Assert.AreEqual(expected, result);
    }
    // [Test]
    public void ApplyOnGoingLocs_Success()
    {
        bool expected = true;

        bool result = game.ApplyOnGoingLocs();

        Assert.AreEqual(expected, result);
        
    }

    [Test]
    public void SkillIronMan_areSuccess()
    {
        DataContractJsonSerializer _serCard = new DataContractJsonSerializer(typeof(List<MarvelCard>));
        DataContractJsonSerializer _serLoc = new DataContractJsonSerializer(typeof(List<MarvelLocation>));
        List<MarvelLocation> locations;
        using (FileStream streamLoc2 = new FileStream(@"..\..\..\..\MarvelSnapProject\Component\Database\locations.json", FileMode.OpenOrCreate))
        {
            locations = (List<MarvelLocation>)_serLoc.ReadObject(streamLoc2);
        }
        // foreach (var loc in locations)
        // {
        //     Console.WriteLine(loc.GetLocationName());
        // }
        List<MarvelCard> importCards;
        using (FileStream streamCard2 = new FileStream(@"..\..\..\..\MarvelSnapProject\Component\Database\cards.json", FileMode.OpenOrCreate))
        {
            importCards = (List<MarvelCard>)_serCard.ReadObject(streamCard2);
        }

        MarvelLocation? loc1 = locations.Find(x => x.GetLocationName() == "Ruins");
        Console.WriteLine(loc1.GetLocationName());
        MarvelCard? ironManCard = importCards.Find(x => x.GetCardName() == "Iron Man");
        MarvelCard? mistyKnightCard = importCards.Find(x => x.GetCardName() == "Misty Knight");
        Console.WriteLine(ironManCard.GetCardName() + mistyKnightCard.GetCardName());
        MarvelPlayer player = new("shely", 011);
        List<MarvelPlayer> players = new();
        players.Add(player);
        
        LocationInfo locInfo = new();
        locInfo.InitLocPlayer(players);
        Dictionary<MarvelLocation, LocationInfo> locsInfo= new();
        locsInfo.Add(loc1, locInfo);
        // locsInfo.Add(loc1, locInfo);
        locsInfo[loc1].SetCardsOnLoc(player, mistyKnightCard);
        // Console.WriteLine(game.GetLocationScore(loc1, player));
        int result = game.GetLocationScore(loc1, player);
        Console.WriteLine(result);

       
    }
}