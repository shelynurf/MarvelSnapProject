namespace MarvelSnapProject;

public class PlayerInfo
{
	private List<ICard>? _deck;
	// private LocPos _playerPos;

	private int _energy;
	private int _locScore;
	private PlayerStatus _playerStatus;


	public PlayerInfo(){
		_deck = new List<ICard>();
		// _playerPos = new LocPos();

	}
	
	
	public bool AddCardToDeck(ICard card)
	{
		_deck?.Add(card);
		return true;
		
	}
	public bool PopCardFromDeck(ICard card)
	{
		_deck?.Remove(card);
		return true;
		
	}
	// public IEnumerable<string> GetPlayerInfo()
	// {

		
		
	// }
	
	// public bool SetLocPos(LocPos locPos)
	// {
	// 	_playerPos = locPos;
	// 	return true;
	// }

	public bool IsCardFullInDecK()
	{
		if (_deck.Count >= 12 )
		{
			return true;
		}
		return false;
	}

	public bool SetEnergy(int energy)
	{
		_energy = energy;
		return true;
	}

	// public int GetLocScore(Ilocation location)
	// {
		
	// }


	
	public bool SetPlayerStatus(PlayerStatus playerStatus)
	
	{
		_playerStatus = playerStatus;
		return true;
	}
}
