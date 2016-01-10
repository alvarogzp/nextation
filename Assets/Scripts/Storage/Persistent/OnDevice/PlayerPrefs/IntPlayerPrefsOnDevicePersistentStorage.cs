using UnityEngine;
using System.Collections;

public class IntPlayerPrefsOnDevicePersistentStorage : PlayerPrefsOnDevicePersistentStorage<int>
{
	private const int DEFAULT_VALUE = 0;

	protected override void setPlayerPref(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	protected override int getPlayerPref(string key)
	{
		return PlayerPrefs.GetInt(key, DEFAULT_VALUE);
	}

	protected override bool existsPlayerPref(string key)
	{
		return getPlayerPref(key) != DEFAULT_VALUE;
	}
}
