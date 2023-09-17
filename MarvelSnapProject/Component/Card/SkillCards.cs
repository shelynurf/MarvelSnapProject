namespace MarvelSnapProject;

public class SkillCards
{
    
    public static bool SkillDefault(GameController game, IPlayer player, MarvelLocation loc)
    {
        return true;
    }

    public static bool SkillIronMan(GameController game, IPlayer player, MarvelLocation loc)
    {
        // MarvelCard? ironMancard = game.GetAllCards().Find(x => x.GetCardName() == "Iron Man");
        Dictionary<MarvelLocation, LocationInfo> locsInfo = game.GetLocationInfo();
        int score = game.GetLocationScore(loc, player);
        locsInfo[loc].SetLocScore(player, score*2);
        return true;
    }
    public static bool SkillMedusa(GameController game, IPlayer player, MarvelLocation loc)
    {
        // MarvelCard? medusaCard = game.GetAllCards().Find(x => x.GetCardName() == "Medusa");
        Dictionary<MarvelLocation, LocationInfo> locsInfo = game.GetLocationInfo();
        // MarvelLocation loc = game.CheckCardLocation(player, medusaCard);

        if (loc == game.OpenedLocation()[1])
        {
            locsInfo[loc].AddScore(player, 3);
        }


        // if (game.GetLocationCards(loc, player).Contains())
        return true;
    }

    public static bool SkillSentinel(GameController game, IPlayer player, MarvelLocation loc)
    {
        MarvelCard? sentinelCard = game.GetAllCards().Find(x => x.GetCardName() == "Sentinel");
        game.GenerateCard(player, sentinelCard);
        return true;
    }

    public static bool SkillBlackPanther(GameController game, IPlayer player, MarvelLocation loc)
    {
        MarvelCard? blackPantherCard = game.GetAllCards().Find(x => x.GetCardName() == "Black Panther");
        Dictionary<MarvelLocation, LocationInfo> locsInfo = game.GetLocationInfo();
        // MarvelLocation loc = game.CheckCardLocation(player, blackPantherCard);
        int power = blackPantherCard.GetCardPower();

        locsInfo[loc].AddScore(player, power);
        return true;
    }

    public static bool SkillAntMan(GameController game, IPlayer player, MarvelLocation loc)
    {
        MarvelCard AntmanCard = game.GetAllCards().Find(x => x.GetCardName() == "Ant Man");
        Dictionary<MarvelLocation, LocationInfo> locsInfo = game.GetLocationInfo();
        var playerCards = game.GetLocationCards(loc, player);
        if (playerCards.Count == 4)
        {
            locsInfo[loc].AddScore(player, 3);
        }			
        return true;
    }
}
