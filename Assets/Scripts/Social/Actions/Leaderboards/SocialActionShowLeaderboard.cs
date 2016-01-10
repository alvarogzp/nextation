using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class SocialActionShowLeaderboard
{
	private string leaderboard = SocialLeaderboards.NO_LEADERBOARD;

	public SocialActionShowLeaderboard()
	{}

	public SocialActionShowLeaderboard(GameMap map)
	{
		leaderboard = SocialLeaderboards.GetLeaderboardForMap(map);
	}

	public void Show()
	{
		if (leaderboard == SocialLeaderboards.NO_LEADERBOARD) {
			showLeaderboards();
		} else {
			showSpecificLeaderboard(leaderboard);
		}
	}

	private void showLeaderboards()
	{
		Social.ShowLeaderboardUI();
	}

	private void showSpecificLeaderboard(string leaderboard)
	{
		SocialPlayGames.Get.ShowLeaderboardUI(leaderboard);
	}
}
