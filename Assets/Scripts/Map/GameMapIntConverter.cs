using UnityEngine;
using System.Collections;

public class GameMapIntConverter
{
	public static GameMap FromInt(int map)
	{
		return (GameMap) map;
	}

	public static int ToInt(GameMap map)
	{
		return (int) map;
	}
}
