using UnityEngine;
using System.Collections;

public class GameObjectFinder
{
	public static GameObject WithName(string name)
	{
		return GameObject.Find(name);
	}

	public static GameObject WithNameLowercasedContainingAndChildOf(string name, GameObject parent)
	{
		foreach (Transform child in parent.transform) {
			if (child.name.ToLower().Contains(name)) {
				return child.gameObject;
			}
		}
		return null;
	}

	public static GameObject WithTag(string tag)
	{
		return GameObject.FindWithTag(tag);
	}

	public static T[] All<T>() where T : Object
	{
		return GameObject.FindObjectsOfType<T>();
	}

	public static T WithName<T>(string name)
	{
		return WithName(name).GetComponent<T>();
	}
}
