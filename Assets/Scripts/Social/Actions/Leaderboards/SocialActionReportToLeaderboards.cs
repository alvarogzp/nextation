using UnityEngine;
using System.Collections;

public class SocialActionReportToLeaderboards
{
	private GamePoints points;

	public SocialActionReportToLeaderboards(GamePoints points)
	{
		this.points = points;
	}

	public void Report()
	{
		reportGeneralScore();
		reportCumulativeScore();
		reportMapScore();
	}

	private void reportGeneralScore()
	{
		reportScore(SocialLeaderboards.GetGeneralLeaderboard(), points.Points);
	}

	private void reportCumulativeScore()
	{
		GameStorage<int> cumulativeScoreStorage = GameStorageKeys.CumulativeScore;
		int previousScore = cumulativeScoreStorage.Exists() ? cumulativeScoreStorage.Get() : 0;
		int currentScore = previousScore + points.Points;
		cumulativeScoreStorage.Set(currentScore);
		reportScore(SocialLeaderboards.GetCumulativeLeaderboard(), currentScore);
	}

	private void reportMapScore()
	{
		reportScore(SocialLeaderboards.GetLeaderboardForMap(points.Map), points.Points);
	}

	private void reportScore(string leaderboard, long score)
	{
		if (leaderboard != SocialLeaderboards.NO_LEADERBOARD) {
			Social.ReportScore(score, leaderboard, (bool sucess) => {
				if (sucess) {
					Log.Debug("Social: Score reported (leaderboard: " + leaderboard + ", score: " + score + ")");
				} else {
					Log.Debug("Social: Failed to report score to leaderboard: " + leaderboard + " (score: " + score + ")");
				}
			});
		} else {
			Log.Debug("Social: No leaderboard to report");
		}
	}
}
