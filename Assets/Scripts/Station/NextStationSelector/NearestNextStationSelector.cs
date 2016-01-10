using UnityEngine;
using System.Collections;

public class NearestNextStationSelector : NextStationSelector
{
	public Station GetNextStation (Station station, Vector3 position, Camera camera)
	{
		return getNearestStationTo(position, station.NextStations, camera);
	}

	private Station getNearestStationTo (Vector3 position, Station[] stations, Camera camera)
	{
		Vector2 position2D = removeZComponent(position);
		return getStationWithMinimumDistanceTo(position2D, stations, camera);
	}
	
	private Station getStationWithMinimumDistanceTo (Vector2 position, Station[] stations, Camera camera)
	{
		Station minimumDistanceStation = null;
		float minimumDistance = float.PositiveInfinity;
		
		foreach (Station s in stations) {
			Vector3 stationPosition = s.transform.position;
			Vector3 screenPosition = getScreenPosition(stationPosition, camera);
			Vector2 screen2DPosition = removeZComponent(screenPosition);
			
			float distance = Vector2.Distance(position, screen2DPosition);
			
			if (distance < minimumDistance) {
				minimumDistanceStation = s;
				minimumDistance = distance;
			}
		}
		
		return minimumDistanceStation;
	}
	
	private Vector3 getScreenPosition (Vector3 worldPosition, Camera camera)
	{
		return camera.WorldToScreenPoint(worldPosition);
	}

	private Vector2 removeZComponent(Vector3 vector)
	{
		return new Vector2(vector.x, vector.y);
	}
}
