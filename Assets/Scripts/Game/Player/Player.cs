public class Player
{
	private string playerName;
	private Train train;
	private bool isLocal;

	public string PlayerName {
		get {
			return playerName;
		}
	}
	public string TrainName {
		get {
			return train.name;
		}
	}
	public Train Train {
		get {
			return train;
		}
	}
	public bool IsLocal {
		get {
			return isLocal;
		}
	}

	public Player(string playerName, Train train, bool isLocal)
	{
		this.playerName = playerName;
		this.train = train;
		this.isLocal = isLocal;
	}
}
