using UnityEngine;
using System.Collections.Generic;

public class SocialEvents
{
	public const string NO_EVENT = "";

	public const string PASSENGERS = "<id removed>";
	public const string TIME = "<id removed>";
	public const string MATCHES = "<id removed>";
	public const string MULTIPLAYER_MATCHES = "<id removed>";
	public const string INDIVIDUAL_MATCHES = "<id removed>";
	public const string LOGGED_IN = "<id removed>";

	private static Dictionary<GameMap, string> mapEvents = new Dictionary<GameMap, string>{
		{GameMap.MAP_04, "<id removed>"}, // Map 1: Extremapa
		{GameMap.MAP_02, "<id removed>"}, // Map 2: Volcano
		{GameMap.MAP_03, "<id removed>"}, // Map 3: Jungla
		{GameMap.MAP_05, "<id removed>"}, // Map 4: Mexico
		{GameMap.MAP_06, "<id removed>"}, // Map 5: Cold map
	};

	public static string GetEventForMap(GameMap map)
	{
		if (!mapEvents.ContainsKey(map)) {
			return NO_EVENT;
		}
		return mapEvents[map];
	}
}
