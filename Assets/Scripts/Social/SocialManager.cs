using UnityEngine;
using System.Collections;

public class SocialManager
{
	private static SocialManager instance = new SocialManager();

	private ActionRunner loggedActionRunner = new ImmediateActionRunner();
	private QueueActionRunner backgroundQueueActionRunner = new UnlimitedQueueActionRunner();
	private QueueActionRunner foregroundQueueActionRunner = new OnlyLastQueueActionRunner();
	private SocialAuthenticator authenticator;

	public static BackgroundSocialActions BackgroundActions {
		get {
			return instance.getBackgroundSocialActions();
		}
	}
	public static ForegroundSocialActions ForegroundActions {
		get {
			return instance.getForegroundSocialActions();
		}
	}

	private SocialManager()
	{
		authenticator = new SocialAuthenticator(new QueueActionRunnerGroup(backgroundQueueActionRunner, foregroundQueueActionRunner));
		init();
	}

	private void init()
	{
		SocialPlayGames.Activate(); // Use PlayGames platform
		authenticator.Init();
		getBackgroundSocialActions().ReportLoggedIn();
	}

	private BackgroundSocialActions getBackgroundSocialActions()
	{
		return new SocialActions(authenticator.Authenticated ? loggedActionRunner : backgroundQueueActionRunner);
	}

	private ForegroundSocialActions getForegroundSocialActions()
	{
		authenticator.Authenticate();
		return new SocialActions(authenticator.Authenticated ? loggedActionRunner : foregroundQueueActionRunner);
	}

	public static void Init()
	{
		// Empty method, when called the class singleton initializes, which is what is wanted
	}
}
