using UnityEngine;
using System.Collections;

public class SocialActionReportToAchievements
{
	private const double PROGRESS_VALUE_TO_UNLOCK_ACHIEVEMENT = 100.0f;

	private CurrentPoints points;
	private bool isMultiplayer;

	public SocialActionReportToAchievements(CurrentPoints points, bool isMultiplayer)
	{
		this.points = points;
		this.isMultiplayer = isMultiplayer;
	}

	public void Report()
	{
		unlockAchievement(SocialAchievements.FIRST_MATCH);
		unlockMultiplayerAchievement();
		incrementAccumulatePointsAchievements();
		unlockPointsInOneMatchAchievements();
	}

	private void unlockMultiplayerAchievement()
	{
		if (isMultiplayer) {
			unlockAchievement(SocialAchievements.MULTIPLAYER_MATCH);
		}
	}

	private void incrementAccumulatePointsAchievements()
	{
		SocialAchievements.ForEachAccumulatePointsAchievement((string achievement) => {
			incrementAchievement(achievement, points.IntPoints);
		});
	}

	private void unlockPointsInOneMatchAchievements()
	{
		SocialAchievements.ForEachPointsInOneMatchAchievement((string achievement, int threshold) => {
			if (points.IntPoints >= threshold) {
				unlockAchievement(achievement);
			}
		});
	}

	private void unlockAchievement(string achievement)
	{
		if (achievement != SocialAchievements.NO_ACHIEVEMENT) {
			Social.ReportProgress(achievement, PROGRESS_VALUE_TO_UNLOCK_ACHIEVEMENT, (bool sucess) => {
				if (sucess) {
					Log.Debug("Social: Achievement unlocked: " + achievement);
				} else {
					Log.Debug("Social: Failed to unlock achievement: " + achievement);
				}
			});
		} else {
			Log.Debug("Social: No achievement to unlock");
		}
	}

	private void incrementAchievement(string achievement, int steps)
	{
		if (achievement != SocialAchievements.NO_ACHIEVEMENT) {
			SocialPlayGames.Get.IncrementAchievement(achievement, steps, (bool sucess) => {
				if (sucess) {
					Log.Debug("Social: Achievement incremented (achievement: " + achievement + ", steps: " + steps + ")");
				} else {
					Log.Debug("Social: Failed to increment achievement: " + achievement + " (steps: " + steps + ")");
				}
			});
		} else {
			Log.Debug("Social: No achievement to increment");
		}
	}
}
