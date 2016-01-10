using UnityEngine;
using System.Collections;

public class GamePoints
{
	private GameMap map;
	private int points;

	public GameMap Map {
		get {
			return map;
		}
	}
	public int Points {
		get {
			return points;
		}
	}

	public GamePoints(GameMap map, int points)
	{
		this.map = map;
		this.points = points;
	}
}
