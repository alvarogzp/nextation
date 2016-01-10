using UnityEngine;
using System.Collections;

public interface NetworkEntityPlaying
{
	void LocalMapLoaded();
	void LocalRouteUpdated(Station nextStation);
	void LocalEndPoints(GamePoints points);
	bool IsPlaying();
}
