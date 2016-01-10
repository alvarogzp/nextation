using UnityEngine;
using System.Collections;

public class Log
{
	public static void Debug(string text)
	{
		if (GameSettings.DEVELOPMENT_MODE) {
			UnityEngine.Debug.Log(text);
		}
	}

	public static void Warn(string text)
	{
		UnityEngine.Debug.LogWarning(text);
	}
}
