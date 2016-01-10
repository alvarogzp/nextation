using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class SocialPlayGames
{
	public static PlayGamesPlatform Get {
		get {
			return PlayGamesPlatform.Instance;
		}
	}

	public static void Activate()
	{
		GooglePlayGames.PlayGamesPlatform.DebugLogEnabled = GameSettings.DEVELOPMENT_MODE;
		GooglePlayGames.PlayGamesPlatform.Activate();
	}
}
