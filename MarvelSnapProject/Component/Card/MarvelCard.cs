using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class MarvelCard : ICard
{
    private string? _cardName;
    private int _cardCost;
    private int _cardPower;
    private CardType _cardType;
    private CardSkill _cardSkill;


    public MarvelCard(string name, int cost, int power, CardType type, CardSkill skill){
        _cardName = name;
        _cardCost = cost;
        _cardPower = power;
        _cardType = type;
        _cardSkill = skill;
    }

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
}
