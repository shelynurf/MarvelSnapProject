namespace MarvelSnapProject;

public class PlayerInfo
{
	private List<MarvelCard>? _deck;
	private List<ICard> _cards;
	// private LocPos _playerPos;

	private int _energy;
	private int _locScore;
	private PlayerStatus _playerStatus;

	private int _maxDeck = 12;


	public PlayerInfo(){
		_deck = new List<MarvelCard>();
		_cards = new List<ICard>();
		// _playerPos = new LocPos();

	}
	
	public List<MarvelCard> GetDeck(){
		return _deck;
	}
	
	public bool AddCardToDeck(MarvelCard card)
	{
		_deck?.Add(card);
		return true;
		// if !_deck.contain(card)
		
	}

	public bool AddCard(MarvelCard card){
		_cards.Add(card);
		return true;
	}
	public bool PopCardFromDeck(MarvelCard card)
	{
		_deck?.Remove(card);
		return true;
		// check card is exist or not
		
	}

	public List<ICard> GetCards(){
		return _cards;
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
		if (_deck.Count >= _maxDeck)
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
