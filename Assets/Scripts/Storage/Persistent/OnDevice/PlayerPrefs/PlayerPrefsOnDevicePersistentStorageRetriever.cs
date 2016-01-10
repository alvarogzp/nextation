using System;

public class PlayerPrefsOnDevicePersistentStorageRetriever
{
	public static PlayerPrefsOnDevicePersistentStorage<T> GetForKey<T>(GameStorageKey key)
	{
		return getByType<T>().ForKey(key);
	}

	private static PlayerPrefsOnDevicePersistentStorage<T> getByType<T>()
	{
		Type tType = typeof(T);
		if (tType == typeof(int)) {
			return getIntPlayerPrefsOnDevicePersistentStorage<T>();
		} else if (tType == typeof(string)) {
			return getStringPlayerPrefsOnDevicePersistentStorage<T>();
		} else if (tType == typeof(bool)) {
			return getBoolPlayerPrefsOnDevicePersistentStorage<T>();
		} else {
			throw new StorageNotFoundException();
		}
	}

	private static PlayerPrefsOnDevicePersistentStorage<T> getIntPlayerPrefsOnDevicePersistentStorage<T>()
	{
		return cast<T>(new IntPlayerPrefsOnDevicePersistentStorage());
	}

	private static PlayerPrefsOnDevicePersistentStorage<T> getStringPlayerPrefsOnDevicePersistentStorage<T>()
	{
		return cast<T>(new StringPlayerPrefsOnDevicePersistentStorage());
	}

	private static PlayerPrefsOnDevicePersistentStorage<T> getBoolPlayerPrefsOnDevicePersistentStorage<T>()
	{
		return cast<T>(new BoolPlayerPrefsOnDevicePersistentStorage());
	}

	private static PlayerPrefsOnDevicePersistentStorage<T> cast<T>(object o)
	{
		return (PlayerPrefsOnDevicePersistentStorage<T>) o;
	}
}
