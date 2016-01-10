using UnityEngine;
using System;
using System.Collections.Generic;

public class SocialAchievements
{
	public const string NO_ACHIEVEMENT = "";

	public const string FIRST_MATCH = "<id removed>";
	public const string MULTIPLAYER_MATCH = "<id removed>";

	private static List<string> accumulatePointsAchievements = new List<string>{
		"<id removed>",
		"<id removed>",
	};

	private static Dictionary<string, int> pointsInOneMatchAchievements = new Dictionary<string, int>{
		{"<id removed>", 500},
	};

	public static void ForEachAccumulatePointsAchievement(Action<string> action)
	{
		accumulatePointsAchievements.ForEach(action);
	}

	public static void ForEachPointsInOneMatchAchievement(Action<string, int> action)
	{
		foreach (KeyValuePair<string, int> achievement in pointsInOneMatchAchievements) {
			action(achievement.Key, achievement.Value);
		}
	}
}
