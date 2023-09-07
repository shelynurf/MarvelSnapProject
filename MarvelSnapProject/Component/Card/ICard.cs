namespace MarvelSnapProject;

public interface ICard
{
    public string? GetCardName();
    public int GetCardCost();
    public int GetCardPower();

    public string GetCardDescription();
    public bool SetCardName(string name);
    public bool SetCardCost(int cost);
    public bool SetCardPower(int power);


}
