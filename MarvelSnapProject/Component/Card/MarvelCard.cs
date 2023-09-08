using System.Runtime.Serialization;

namespace MarvelSnapProject;

[DataContract]
public class MarvelCard : ICard
{
    [DataMember] private string? _cardName;
    [DataMember] private int _cardCost;
    [DataMember] private int _cardPower;
    [DataMember] private CardType _cardType;
    [DataMember] private CardSkill _cardSkill;
    [DataMember] private string _cardDescription = "";


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

    public CardType GetCardType(){
        return _cardType;
    }

    public string? GetCardDescription(){
        return _cardDescription;
    }

    public MarvelCard Copy(){
        MarvelCard copy = (MarvelCard)this.MemberwiseClone();
        copy._cardName = _cardName;
        return copy;
    }

    // public bool Action(Delegate action)
    // {
    //     delegate.Invoke();
    //     return true;
    // }
}
