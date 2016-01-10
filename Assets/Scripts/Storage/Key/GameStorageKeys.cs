public class GameStorageKeys
{
	// Global keys
	public static GameStorage<string> SelectedTrain {
		get {
			return getVolatile<string>(globalKey("SelectedTrain"));
		}
	}

	public static GameStorage<string> SelectedMap {
		get {
			return getVolatile<string>(globalKey("SelectedMap"));
		}
	}

	public static GameStorage<GameType> SelectedGameType {
		get {
			return getVolatile<GameType>(globalKey("SelectedGameType"));
		}
	}

	public static GameStorage<MultiplayerRole> SelectedMultiplayerRole {
		get {
			return getVolatile<MultiplayerRole>(globalKey("SelectedMultiplayerRole"));
		}
	}

	public static GameStorage<NetworkTrainPlayers> NetworkTrains {
		get {
			return getVolatile<NetworkTrainPlayers>(globalKey("NetworkTrains"));
		}
	}

	public static GameStorage<NetworkEntityPlaying> NetworkEntityPlaying {
		get {
			return getVolatile<NetworkEntityPlaying>(globalKey("NetworkEntityPlaying"));
		}
	}

	public static GameStorage<bool> SoundDisabled {
		get {
			return getPersistent<bool>(globalKey("SoundDisabled"));
		}
	}

	public static GameStorage<int> CumulativeScore {
		get {
			return getPersistent<int>(globalKey("CumulativeScore"));
		}
	}

	public static GameStorage<bool> SocialUser {
		get {
			return getPersistent<bool>(globalKey("SocialUser"));
		}
	}

	// Map specific keys
	public static GameStorage<int> MaxPoints(GameMap map)
	{
		return getPersistent<int>(forMapKey(map, "MaxPoints"));
	}

	// Helper functions
	private static GameStorage<T> getVolatile<T>(GameStorageKey key)
	{
		return retriever(key).GetVolatileOnMemory<T>();
	}

	private static GameStorage<T> getPersistent<T>(GameStorageKey key)
	{
		return retriever(key).GetPersistentOnDevice<T>();
	}

	private static GameStorageRetriever retriever(GameStorageKey key)
	{
		return GameStorageRetriever.ForKey(key);
	}

	private static GameStorageKey globalKey(string key)
	{
		return GameStorageKeyFactory.GetGlobalKey(key);
	}

	private static GameStorageKey forMapKey(GameMap map, string key)
	{
		return GameStorageKeyFactory.GetKeyForMap(map, key);
	}
}
