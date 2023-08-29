namespace MarvelSnapProject;

public abstract class CardAbstract
{
    private string? _cardName;
    private int _cardEnergy;
    private int _cardPower;

    public bool SetCardName(string name)
    {
        _cardName = name;
        return true;
    }
    public bool SetCardEnergy(int energy)
    {
        _cardEnergy = energy;
        return true;
    }
    public bool SetCardPower(int power)
    {
        _cardPower = power;
        return true;
    }

    public string GetCardName(){
        return _cardName;
    }

    public int GetCardEnergy(){
        return _cardEnergy;
    }

    public int GetCardPower(){
        return _cardPower;
    }

    public abstract void Ability();
}
