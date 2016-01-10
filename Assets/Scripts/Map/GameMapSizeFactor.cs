using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMapSizeFactor
{
	private const float DEFAULT_FACTOR = 1f;

	private static Dictionary<GameMap, float> factors = new Dictionary<GameMap, float>{
		{GameMap.MAP_01, 1f},
		{GameMap.MAP_02, 0.4f},
		{GameMap.MAP_03, 0.35f},
		{GameMap.MAP_04, 1f},
		{GameMap.MAP_05, 1.35f},
		{GameMap.MAP_06, 1.3f},
	};

	private float relativeFactor = 1f;

	public GameMapSizeFactor(GameMap relativeTo)
	{
		this.relativeFactor = GetFactorForMap(relativeTo);
	}

	public float GetFactorForMap(GameMap map)
	{
		float factor = DEFAULT_FACTOR;
		if (factors.ContainsKey(map)) {
			factor = factors[map];
		}

		return factor / relativeFactor;
	}

	public static float GetFactorForMapRelativeToAnotherMap(GameMap map, GameMap relativeTo)
	{
		return new GameMapSizeFactor(relativeTo).GetFactorForMap(map);
	}

	public static float GetFactorForCurrentMapRelativeToMap(GameMap relativeTo)
	{
		return GetFactorForMapRelativeToAnotherMap(CurrentMap.GetCurrentMap(), relativeTo);
	}

	public static float GetFactorForCurrentMapRelativeToFirstMap()
	{
		return GetFactorForMapRelativeToAnotherMap(CurrentMap.GetCurrentMap(), GameMap.MAP_01);
	}
}
