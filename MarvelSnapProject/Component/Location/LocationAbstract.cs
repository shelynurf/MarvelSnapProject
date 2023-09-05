namespace MarvelSnapProject;

public abstract class LocationAbstract : Ilocation
{
    private string? _locationName;
    private Dictionary<LocPos, List<CardAbstract>> _posCard;
    private Dictionary<LocPos, int> _locEnergy;
    private bool _isFull;
    private LocationSkill _locSkill;

    // public MarvelLocation(string name, LocationSkill skill){
    //     _locationName = name;
    //     _locSkill = skill;
    // }

    public string GetLocationName(){
        return _locationName;
    }
    public bool SetLocationName(string? locationName){
        _locationName = locationName;
        return true;
    }
    public bool AddCard(PlayerInfo playerInfo, ICard card, LocPos locPos){
        return true;
    }

    public bool SetIsFull(bool check){
        _isFull = check;
        return _isFull;
    }

    public bool IsEnergyEligible(ICard card){
        return true;
    }

    public abstract void LocationEffect(GameController gameController);


}
