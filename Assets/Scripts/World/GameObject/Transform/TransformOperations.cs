using UnityEngine;
using System.Collections;

public class TransformOperations
{
	private Transform transform;

	protected TransformOperations(Transform transform)
	{
		this.transform = transform;
	}

	public static TransformOperations To(Transform transform)
	{
		return new TransformOperations(transform);
	}

	public TransformOperations SetPosition(Vector3 position)
	{
		transform.position = position;
		return this;
	}

	public TransformOperations SetRotationTo(Vector3 position)
	{
		return SetRotation(GetRotationTo(position));
	}

	public TransformOperations SetRotation(Quaternion rotation)
	{
		transform.rotation = rotation;
		return this;
	}

	public TransformOperations SetParent(Transform parent)
	{
		transform.parent = parent;
		return this;
	}

	public TransformOperations AddChild(Transform child)
	{
		child.parent = transform;
		return this;
	}

	private Quaternion GetRotationTo(Vector3 position)
	{
		Vector3 direction = position - transform.position;
		return Quaternion.LookRotation(direction);
	}
}
