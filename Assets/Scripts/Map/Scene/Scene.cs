using UnityEngine;
using System.Collections;

public class Scene
{
	public static string GetCurrentSceneName()
	{
		return Application.loadedLevelName;
	}
}
