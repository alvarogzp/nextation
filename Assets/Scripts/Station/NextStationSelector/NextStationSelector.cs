using UnityEngine;

public interface NextStationSelector
{
	Station GetNextStation (Station station, Vector3 position, Camera camera);
}
