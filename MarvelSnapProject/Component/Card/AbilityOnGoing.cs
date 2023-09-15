namespace MarvelSnapProject;

public class AbilityOnGoing
{
    public static bool SkillDefault(GameController game)
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
}