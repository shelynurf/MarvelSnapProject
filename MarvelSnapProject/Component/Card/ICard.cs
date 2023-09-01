namespace MarvelSnapProject;

public interface ICard
{
    public string GetCardName();
    public int GetCardEnergy();
    public int GetCardPower();
    public bool SetCardName(string name);
    public bool SetCardEnergy(int energy);
    public bool SetCardPower(int power);


}
