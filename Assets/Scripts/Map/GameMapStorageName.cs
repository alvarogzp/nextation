using UnityEngine;
using System.Collections;

public class GameMapStorageName
{
	public const string MAP_FORMAT = "Map{0:D2}";

	public static string GetStorageName(GameMap map)
	{
		int mapNumber = GameMapIntConverter.ToInt(map);
		return string.Format(MAP_FORMAT, mapNumber);
	}
}
