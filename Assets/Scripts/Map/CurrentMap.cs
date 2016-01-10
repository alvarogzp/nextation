using UnityEngine;
using System.Collections;

public class CurrentMap
{
	public static GameMap GetCurrentMap()
	{
		return SceneToGameMapMapper.GetMap(Scene.GetCurrentSceneName());
	}

	public static bool isMap()
	{
		return GetCurrentMap() != GameMap.MAP_UNKNOWN;
	}
}
