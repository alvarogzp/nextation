using UnityEngine;
using System.Collections.Generic;

public abstract class PlayerPrefsOnDevicePersistentStorage<T> : GameStorage<T>
{
	private GameStorageKey key;

	protected abstract void setPlayerPref(string key, T value);
	protected abstract T getPlayerPref(string key);
	protected abstract bool existsPlayerPref(string key);

	public PlayerPrefsOnDevicePersistentStorage<T> ForKey(GameStorageKey key)
	{
		this.key = key;
		return this;
	}

	public void Set(T value)
	{
		setPlayerPref(key.Key, value);
		syncPlayerPrefs();
	}

	private void syncPlayerPrefs()
	{
		PlayerPrefs.Save();
	}

	public T Get()
	{
		if (!Exists()) {
			throw new KeyNotFoundException();
		}
		return getPlayerPref(key.Key);
	}

	public bool Exists()
	{
		return existsPlayerPref(key.Key);
	}

	public void Delete()
	{
		PlayerPrefs.DeleteKey(key.Key);
	}
}
