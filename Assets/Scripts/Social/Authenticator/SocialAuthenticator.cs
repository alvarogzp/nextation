using UnityEngine;
using System.Collections;

public class SocialAuthenticator
{
	private static bool isAuthenticating = false;
	private QueueActionRunner queuedActions;
	private GameStorage<bool> socialUserStorage = GameStorageKeys.SocialUser;

	public bool Authenticated {
		get {
			return authenticated();
		}
	}

	public SocialAuthenticator(QueueActionRunner queuedActions)
	{
		this.queuedActions = queuedActions;
	}

	public void Init()
	{
		if (!socialUserStorage.Exists() || socialUserStorage.Get() == true) {
			Authenticate();
		}
	}

	public void Authenticate()
	{
		if (!isAuthenticating && !authenticated()) {
			isAuthenticating = true;
			Log.Debug("Social: Authenticating...");
			Social.localUser.Authenticate(authenticationResult);
		}
	}

	private void authenticationResult(bool success)
	{
		isAuthenticating = false;
		if (success) {
			successfulAuthentication();
		} else {
			failedAuthentication();
		}
	}

	private void successfulAuthentication()
	{
		Log.Debug("Social: Authenticated");
		socialUserStorage.Set(true);
		queuedActions.RunAndClearQueue();
	}

	private void failedAuthentication()
	{
		Log.Debug("Social: Authentication failed");
		socialUserStorage.Set(false);
	}

	private bool authenticated()
	{
		return Social.localUser.authenticated;
	}
}
