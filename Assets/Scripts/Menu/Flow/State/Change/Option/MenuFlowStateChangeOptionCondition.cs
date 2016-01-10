public class MenuFlowStateChangeOptionCondition
{
	public delegate bool Delegate();

	public static bool Always()
	{
		return true;
	}

	public static bool GameTypeIsOffline()
	{
		return getGameType() == GameType.Offline;
	}

	public static bool GameTypeIsOnline()
	{
		return getGameType() == GameType.Online;
	}

	public static bool MultiplayerRoleIsServer()
	{
		return getMultiplayerRole() == MultiplayerRole.Server;
	}

	public static bool MultiplayerRoleIsClient()
	{
		return getMultiplayerRole() == MultiplayerRole.Client;
	}

	// Helpers
	private static GameType getGameType()
	{
		GameType gameType = GameType.Offline;

		GameStorage<GameType> selectedGameTypeStorage = GameStorageKeys.SelectedGameType;
		if (selectedGameTypeStorage.Exists()) {
			gameType = selectedGameTypeStorage.Get();
		}

		return gameType;
	}

	private static MultiplayerRole getMultiplayerRole()
	{
		MultiplayerRole role = MultiplayerRole.Server;

		GameStorage<MultiplayerRole> selectedMultiplayerRoleStorage = GameStorageKeys.SelectedMultiplayerRole;
		if (selectedMultiplayerRoleStorage.Exists()) {
			role = selectedMultiplayerRoleStorage.Get();
		}

		return role;
	}
}
