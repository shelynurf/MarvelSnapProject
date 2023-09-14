using System.Runtime.Serialization;

namespace MarvelSnapProject;
public delegate bool LocationDelegate(GameController game);

[DataContract]
public class MarvelLocation : ILocation
{
    [DataMember] private string _locationName;
    // private Dictionary<LocPos, List<CardAbstract>> _posCard = new();
    // private Dictionary<LocPos, int> _locEnergy = new();
    private bool _isFull;
    [DataMember] private LocationSkill _locSkill;
    [DataMember] private string _locDescription;
    private bool _isOpened = false;
    private LocationDelegate _action;
    

    public MarvelLocation(string name, LocationSkill skill){
        _locationName = name;
        _locSkill = skill;
    }

    public string GetLocationName(){
        return _locationName;
    }
    public bool SetLocationName(string locationName){
        _locationName = locationName;
        return true;
    }

    public string GetLocDescription()
    {
        return _locDescription;
    }

    public LocationSkill GetSkill()
    {
        return _locSkill;
    }
    // public bool AddCard(PlayerInfo playerInfo, ICard card, LocPos locPos){
    //     return true;
    // }

    // public bool SetIsFull(bool check){
    //     _isFull = check;
    //     return _isFull;
    // }

    // public bool IsEnergyEligible(ICard card){
    //     return true;
    // }
    public bool SetIsOpened(bool isOpened){
        _isOpened = isOpened;
        return _isOpened;
    }

    public bool CheckIsOpened()
    {
        return _isOpened;
    }

    public bool Action(LocationDelegate action, GameController game)
    {
        _action = action;
        _action.Invoke(game);
        return true;
    }

}
