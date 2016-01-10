public class GameStorageKeyFactory
{
	private const string KEY_MAP_SEPARATOR = "-";

	public static GameStorageKey GetKeyForMap(GameMap map, string key)
	{
		string mapKey = GameMapStorageName.GetStorageName(map) + KEY_MAP_SEPARATOR + key;
		return getKey(mapKey);
	}

	public static GameStorageKey GetGlobalKey(string key)
	{
		return getKey(key);
	}

	private static GameStorageKey getKey(string key)
	{
		return new GameStorageKey(key);
	}
}
