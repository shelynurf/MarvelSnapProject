namespace MarvelSnapProject;

public abstract class CardAbstract : ICard
{
    private string? _cardName;
    private int _cardCost;
    private int _cardPower;

    public bool SetCardName(string name)
    {
        _cardName = name;
        return true;
    }
    public bool SetCardCost(int cost)
    {
        _cardCost = cost;
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

    public int GetCardCost(){
        return _cardCost;
    }

    public int GetCardPower(){
        return _cardPower;
    }

    public abstract void Ability(GameController gameController);
}
