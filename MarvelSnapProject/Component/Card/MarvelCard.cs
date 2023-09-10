using System.Runtime.Serialization;

namespace MarvelSnapProject;

public delegate bool ActionDelegate(GameController game, IPlayer player, MarvelLocation loc);
[DataContract]
public class MarvelCard : ICard
{
    [DataMember] private string? _cardName;
    [DataMember] private int _cardCost;
    [DataMember] private int _cardPower;
    [DataMember] private CardType _cardType;
    [DataMember] private CardSkill _cardSkill;
    [DataMember] private string _cardDescription = "";
    private ActionDelegate _action; 
    private bool _isAffected = false;


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

    public CardSkill GetCardSkill()
    {
        return _cardSkill;
    }

    public string? GetCardDescription(){
        return _cardDescription;
    }

    public bool IsAffected()
    {
        return _isAffected;
    }

    public bool SetAffected(bool state)
    {
        _isAffected = state;
        return true;
    }

    public MarvelCard Copy(){
        MarvelCard copy = (MarvelCard)this.MemberwiseClone();
        copy._cardName = _cardName;
        return copy;
    }

    public bool Action(ActionDelegate action, GameController game, IPlayer player, MarvelLocation loc)
    {
        _action = action;
        _action.Invoke(game, player, loc);
        return true;
    }
}
