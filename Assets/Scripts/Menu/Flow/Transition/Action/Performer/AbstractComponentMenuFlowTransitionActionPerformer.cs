using UnityEngine;
using System.Collections;

public abstract class AbstractComponentMenuFlowTransitionActionPerformer : MenuFlowTransitionActionPerformer
{
	public abstract void Perform(string target);

	protected T get<T>(string gameObjectName)
	{
		GameObject gameObject = find(gameObjectName);
		return gameObject.GetComponent<T>();
	}

	private GameObject find(string gameObjectName)
	{
		GameObject gameObject = GameObjectFinder.WithName(gameObjectName);
		if (gameObject == null) {
			throw new GameObjectNotFoundException(gameObjectName);
		}
		return gameObject;
	}
}
