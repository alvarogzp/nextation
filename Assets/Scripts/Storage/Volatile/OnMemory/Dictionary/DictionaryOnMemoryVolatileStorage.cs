using System.Collections.Generic;

public class DictionaryOnMemoryVolatileStorage<T> : GameStorage<T>
{
	private static Dictionary<string, object> dictionary = new Dictionary<string, object>();

	private GameStorageKey key;

	public DictionaryOnMemoryVolatileStorage(GameStorageKey key)
	{
		this.key = key;
	}

	public void Set(T value)
	{
		dictionary[key.Key] = value;
	}

	public T Get()
	{
		return (T) dictionary[key.Key];
	}

	public bool Exists()
	{
		return dictionary.ContainsKey(key.Key);
	}

	public void Delete()
	{
		dictionary.Remove(key.Key);
	}
}
