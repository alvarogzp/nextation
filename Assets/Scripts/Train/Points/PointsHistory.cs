using UnityEngine;
using System.Collections;

public class PointsHistory
{
	private const int DEFAULT_MAX_POINTS = 0;

	private GameMap map;
	private GameStorage<int> maxPointsStorage;

	public PointsHistory(GameMap map)
	{
		this.map = map;
		maxPointsStorage = GameStorageKeys.MaxPoints(map);
	}

	public GamePoints GetMaxPoints()
	{
		return new GamePoints(map, maxPointsStorage.Exists() ? maxPointsStorage.Get() : DEFAULT_MAX_POINTS);
	}

	public void AddPoints(GamePoints points)
	{
		if (GetMaxPoints().Points < points.Points) {
			setMaxPoints(points);
		}
	}

	private void setMaxPoints(GamePoints points)
	{
		maxPointsStorage.Set(points.Points);
	}
}
