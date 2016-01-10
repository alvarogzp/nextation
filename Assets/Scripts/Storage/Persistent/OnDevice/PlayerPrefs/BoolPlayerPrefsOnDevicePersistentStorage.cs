using UnityEngine;
using System.Collections;

public class BoolPlayerPrefsOnDevicePersistentStorage : PlayerPrefsOnDevicePersistentStorage<bool>
{
	private const int DEFAULT_VALUE = -1;

	protected override void setPlayerPref(string key, bool value)
	{
		PlayerPrefs.SetInt(key, boolToInt(value));
	}

	protected override bool getPlayerPref(string key)
	{
		return intToBool(getPlayerPrefInt(key));
	}

	protected override bool existsPlayerPref(string key)
	{
		return getPlayerPrefInt(key) != DEFAULT_VALUE;
	}

	private int getPlayerPrefInt(string key)
	{
		return PlayerPrefs.GetInt(key, DEFAULT_VALUE);
	}

	private bool intToBool(int i)
	{
		return i != 0;
	}

	private int boolToInt(bool b)
	{
		return b ? 1 : 0;
	}
}
