
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

    [Test]
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
    [Test]
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
}