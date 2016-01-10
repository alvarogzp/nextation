using UnityEngine;
using System.Collections;

public class GameStorageRetriever
{
	private GameStorageKey key;

	private GameStorageRetriever(GameStorageKey key)
	{
		this.key = key;
	}

	public static GameStorageRetriever ForKey(GameStorageKey key)
	{
		return new GameStorageRetriever(key);
	}

	public GameStorage<T> GetPersistentOnDevice<T>()
	{
		return PlayerPrefsOnDevicePersistentStorageRetriever.GetForKey<T>(key);
	}

	public GameStorage<T> GetVolatileOnMemory<T>()
	{
		return DictionaryOnMemoryVolatileStorageRetriever.GetForKey<T>(key);
	}
}
