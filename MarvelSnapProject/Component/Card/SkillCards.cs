namespace MarvelSnapProject;

public class SkillCards
{
    public bool SkillDefault(GameController game)
    {
        return true;
    }
    public bool SkillIronMan(GameController game, IPlayer player, MarvelLocation loc)
    {
        int score = game.GetLocationScore(loc, player);
        
        score = score * 2;
        return true;
    }

    public bool SkillMedusa(GameController game)
    {
        return true;
    }

    public bool SkillSentinel(GameController game)
    {
        return true;
    }

    public bool SkillAntman(GameController game)
    {
        return true;
    }
}