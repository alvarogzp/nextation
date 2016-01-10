using UnityEngine;
using System.Collections;

public class PointsHistoryFactory
{
	public static PointsHistory GetForMap(GameMap map)
	{
		return new PointsHistory(map);
	}

	public static PointsHistory GetForCurrentMap()
	{
		return GetForMap(CurrentMap.GetCurrentMap());
	}
}
