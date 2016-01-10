using UnityEngine;
using System.Collections;

public class StringPlayerPrefsOnDevicePersistentStorage : PlayerPrefsOnDevicePersistentStorage<string>
{
	private const string DEFAULT_VALUE = "";

	protected override void setPlayerPref(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	protected override string getPlayerPref(string key)
	{
		return PlayerPrefs.GetString(key, DEFAULT_VALUE);
	}

	protected override bool existsPlayerPref(string key)
	{
		return getPlayerPref(key) != DEFAULT_VALUE;
	}
}
