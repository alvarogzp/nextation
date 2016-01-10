using UnityEngine;
using System.Collections;

public class GameObjectOperations : TransformOperations
{
	private GameObject gameObject;

	public GameObject GameObject {
		get {
			return gameObject;
		}
	}

	private GameObjectOperations(GameObject gameObject)
		: base(gameObject.transform)
	{
		this.gameObject = gameObject;
	}

	public static GameObjectOperations To(GameObject gameObject)
	{
		return new GameObjectOperations(gameObject);
	}

	public GameObjectOperations Hide()
	{
		Renderer renderer = gameObject.GetComponent<Renderer>();
		if (renderer != null) {
			renderer.enabled = false;
		}
		return this;
	}

	public GameObjectOperations AddComponent<T>() where T : Component
	{
		gameObject.AddComponent<T>();
		return this;
	}

	public GameObjectOperations RemoveComponent<T>() where T : Component
	{
		Object.Destroy(gameObject.GetComponent<T>());
		return this;
	}

	public GameObjectOperations SetParent(GameObject gameObject)
	{
		base.SetParent(gameObject.transform);
		return this;
	}

	public GameObjectOperations AddChild(GameObject gameObject)
	{
		base.AddChild(gameObject.transform);
		return this;
	}

	public GameObjectOperations SetPosition(GameObject gameObject)
	{
		base.SetPosition(gameObject.transform.position);
		return this;
	}

	public GameObjectOperations SetRotation(GameObject gameObject)
	{
		base.SetRotation(gameObject.transform.rotation);
		return this;
	}

	public GameObjectOperations SetRotationTo(GameObject gameObject)
	{
		base.SetRotationTo(gameObject.transform.position);
		return this;
	}

	public GameObjectOperations Clone(string name)
	{
		GameObject newGameObject = Object.Instantiate(gameObject);
		newGameObject.name = name;
		return new GameObjectOperations(newGameObject);
	}

	public GameObjectOperations SetTag(string tag)
	{
		gameObject.tag = tag;
		return this;
	}
}
