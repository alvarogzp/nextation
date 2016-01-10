using UnityEngine;
using System.Collections.Generic;

public class SocialLeaderboards
{
	public const string NO_LEADERBOARD = "";

	private const string GENERAL_LEADERBOARD = "<id removed>";
	private const string CUMULATIVE_LEADERBOARD = "<id removed>";

	private static Dictionary<GameMap, string> leaderboards = new Dictionary<GameMap, string>{
		{GameMap.MAP_04, "<id removed>"}, // Map 1: Extremapa
		{GameMap.MAP_02, "<id removed>"}, // Map 2: Volcano
		{GameMap.MAP_03, "<id removed>"}, // Map 3: Jungla
		{GameMap.MAP_05, "<id removed>"}, // Map 4: Mexico
		{GameMap.MAP_06, "<id removed>"}, // Map 5: Cold map
	};

	public static string GetLeaderboardForMap(GameMap map)
	{
		if (!leaderboards.ContainsKey(map)) {
			return NO_LEADERBOARD;
		}
		return leaderboards[map];
	}

	public static string GetGeneralLeaderboard()
	{
		return GENERAL_LEADERBOARD;
	}

	public static string GetCumulativeLeaderboard()
	{
		return CUMULATIVE_LEADERBOARD;
	}
}
