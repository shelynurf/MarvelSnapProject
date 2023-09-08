namespace MarvelSnapProject;

public class PlayerInfo
{
	private List<MarvelCard>? _deck;
	private List<MarvelCard> _cards;
	// private LocPos _playerPos;

	private int _energy;
	private Dictionary<MarvelLocation, int> _locScore;
	private Dictionary<MarvelLocation, PlayerStatus> _playerStatus;

	private int _maxDeck = 12;
	private int _totalWin;


	public PlayerInfo(){
		_deck = new List<MarvelCard>();
		_cards = new List<MarvelCard>();
		// _playerPos = new LocPos();

	}
	
	public List<MarvelCard> GetDeck(){
		return _deck;
	}
	
	public int GetMaxDeck(){
		return _maxDeck;
	}
	public bool AddCardToDeck(MarvelCard card)
	{
		if (!_deck.Contains(card))
		{
			_deck?.Add(card);
		return true;
		}
		return false;
	}

	public bool PopCardFromDeck(MarvelCard card)
	{
		if (_deck.Contains(card))
		{
			_deck.Remove(card);
		return true;
		}
		return false;		
	}

	public bool AddCard(MarvelCard card){
		if (!_cards.Contains(card))
		{
			_cards.Add(card);
		return true;
		}
		return false;
	}

	public bool RemoveCard(MarvelCard card)
	{
		if (_cards.Contains(card))
		{
			_cards.Remove(card);
			return true;
		}
		return false;
	}

	public int GetEnergy()
	{
		return _energy;
	}
	

	public List<MarvelCard> GetCards(){
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

	public bool AddTotalWin()
	{
		_totalWin += 1;
		return true;
	}

	public int GetTotalWin()
	{
		return _totalWin;
	}


	// public int GetLocScore(Ilocation location)
	// {
		
	// }


	
	// public bool SetPlayerStatus(MarvelLocation loc, PlayerStatus playerStatus)
	
	// {
	// 	_playerStatus[loc] = playerStatus;
	// 	return true;
	// }
}
