using UnityEngine;
using System.Collections;

public class MatchingNextStationSelector : NextStationSelector
{
	public Station GetNextStation (Station station, Vector3 position, Camera camera)
	{
		GameObject gameObject = getGameObjectCollided(position, camera);
		if (gameObject) {
			Station matchingStation = getStation(gameObject);
			if (inList (matchingStation, station.NextStations)) {
				return matchingStation;
			}
		}
		return null;
	}

	private GameObject getGameObjectCollided(Vector3 position, Camera camera)
	{
		Ray ray = camera.ScreenPointToRay(position);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		return hit.collider ? hit.collider.gameObject : null;
	}

	private Station getStation(GameObject gameObject)
	{
		return gameObject.GetComponent<Station>();
	}

	private bool inList(Station station, Station[] stations)
	{
		foreach (Station s in stations) {
			if (station == s) {
				return true;
			}
		}
		return false;
	}
}
