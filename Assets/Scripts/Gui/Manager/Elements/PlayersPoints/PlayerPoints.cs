public class PlayerPoints
{
	private Player player;
	private CurrentPoints points;

	public string PlayerName {
		get {
			return player.PlayerName;
		}
	}
	public int Points {
		get {
			return getPoints();
		}
	}
	public bool Ended {
		get {
			return points.Ended;
		}
	}

	public PlayerPoints(Player player, CurrentPoints points)
	{
		this.player = player;
		this.points = points;
	}

	private int getPoints()
	{
		return Ended ? getEndPoints() : points.IntPoints;
	}

	private int getEndPoints()
	{
		if (player is NetworkTrainPlayer) {
			GamePoints remoteEndPoints = ((NetworkTrainPlayer) player).GetEndPoints();
			if (remoteEndPoints != null) {
				return remoteEndPoints.Points;
			}
		}
		return points.IntPoints;
	}
}
