namespace MarvelSnapProject;

public class SkillCards
{
    public static bool SkillDefault(GameController game, IPlayer player, MarvelLocation loc)
    {
        return true;
    }
    public static bool SkillIronMan(GameController game)
    {
        List<MarvelLocation> locs = game.GetLocations();
        IEnumerable<IPlayer> players = game.ListAllPlayer();

        foreach (MarvelLocation loc in locs)
        {
            foreach (IPlayer player in players)
            {
                MarvelCard? ironManCard = game.GetAllCards().Find(x => x.GetCardName() == "Iron Man");
                Dictionary<MarvelLocation, LocationInfo> locsInfo = game.GetLocationInfo();
                var cards = locsInfo[loc].GetCardsOnLoc()[player];
                int score = game.GetLocationScore(loc, player);
                if (cards.Contains(ironManCard))
                {
                    score = score * 2;
                    return true;
                }
                

                // MarvelLocation loc = game.CheckCardLocation(player, ironManCard);
            }

        }
        return false;

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

    public bool SkillAntman(GameController game, IPlayer player, MarvelLocation loc)
    {
        return true;
    }
}
