using UnityEngine;
using System.Collections;

public class StationNameObjectFinder
{
	private const string STATION_OBJECT_NAME_CONTAINS = "building";

	public static GameObject GetStationNameObject(Station station)
	{
		return GameObjectFinder.WithNameLowercasedContainingAndChildOf(STATION_OBJECT_NAME_CONTAINS, station.gameObject);
	}
}
