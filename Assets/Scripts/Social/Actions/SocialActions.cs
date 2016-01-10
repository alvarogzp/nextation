using UnityEngine;
using System;

public class SocialActions : BackgroundSocialActions, ForegroundSocialActions
{
	private ActionRunner runner;

	public SocialActions(ActionRunner runner)
	{
		this.runner = runner;
	}

	public void ShowLeaderboards()
	{
		run(() => {
			new SocialActionShowLeaderboard().Show();
		});
	}

	public void ShowLeaderboard(GameMap map)
	{
		run(() => {
			new SocialActionShowLeaderboard(map).Show();
		});
	}

	public void ShowAchievements()
	{
		run(() => {
			SocialActionShowAchievements.Show();
		});
	}

	public void ReportLoggedIn()
	{
		run(() => {
			SocialActionReportToEvents.ReportLoggedIn();
		});
	}

	public void ReportMatchEnd(CurrentPoints points, bool isMultiplayer)
	{
		run(() => {
			new SocialActionReportToEvents(points, isMultiplayer).Report();
			new SocialActionReportToAchievements(points, isMultiplayer).Report();
			new SocialActionReportToLeaderboards(points.GetPoints()).Report();
		});
	}

	private void run(Action action)
	{
		runner.Run(action);
	}
}
