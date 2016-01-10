using UnityEngine;
using System.Collections;
using System;

public class SceneToGameMapMapper
{
	public const string SCENE_NAME_PREFIX = "Map";

	public static GameMap GetMap(string sceneName)
	{
		if (sceneName.StartsWith(SCENE_NAME_PREFIX)) {
			try {
				string mapNumberPart = sceneName.Substring(SCENE_NAME_PREFIX.Length);
				int mapNumber = int.Parse(mapNumberPart);
				return GameMapIntConverter.FromInt(mapNumber);
			} catch (FormatException) {}
		}

		return GameMap.MAP_UNKNOWN;
	}
}
