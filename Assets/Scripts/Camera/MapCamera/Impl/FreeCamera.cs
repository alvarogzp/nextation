using UnityEngine;
using System.Collections;

public class FreeCamera : AbstractCamera
{
	private const float MOVEMENT_SPEED_FOR_MAP_01 = 2;
	private const float MOVEMENT_LIMIT_FOR_MAP_01 = 150;
	private const string FREE_CAMERA_NAME = "FreeCamera";

	private Camera originalCamera;
	private DragMouseMovement movement;

	public FreeCamera(Camera original)
	{
		originalCamera = original;
	}

	public override void Activate()
	{
		camera = clone(originalCamera);
		movement = new DragMouseMovement(camera.transform, getSpeed(), getLimit());
		base.Activate();
	}

	private Camera clone(Camera camera)
	{
		return GameObjectOperations.To(camera.gameObject).Clone(FREE_CAMERA_NAME).RemoveComponent<AudioListener>().GameObject.GetComponent<Camera>();
	}

	private float getSpeed()
	{
		return MOVEMENT_SPEED_FOR_MAP_01 * GameMapSizeFactor.GetFactorForCurrentMapRelativeToFirstMap();
	}

	private float getLimit()
	{
		return MOVEMENT_LIMIT_FOR_MAP_01 * GameMapSizeFactor.GetFactorForCurrentMapRelativeToFirstMap();
	}

	public override void Update()
	{
		movement.Update();
	}

	public override void Deactivate()
	{
		Object.Destroy(camera.gameObject);
	}
}
