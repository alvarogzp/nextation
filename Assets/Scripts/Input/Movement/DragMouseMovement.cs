using UnityEngine;
using System.Collections;

public class DragMouseMovement
{
	private const int MOUSE_BUTTON = 0;

	private Transform transform;
	private float speed;
	private float directRotationFactor;
	private float inverseRotationFactor;
	private Vector3 startPosition;
	private float limit;

	private Vector3 lastMousePosition = Input.mousePosition;

	public DragMouseMovement(Transform transform, float speed, float limit)
	{
		this.transform = transform;
		this.speed = speed * (1 / Pixels.ScreenDpiFactor);
		this.inverseRotationFactor = transform.eulerAngles.y / 90;
		this.directRotationFactor = 1 - inverseRotationFactor;
		this.startPosition = transform.position;
		this.limit = limit;
	}

	public void Update()
	{
		if (wasMousePressedNow()) {
			doMousePressedNowAction();
		}
		if (isMousePressed()) {
			doMousePressedAction();
		}
	}

	private bool wasMousePressedNow()
	{
		return Input.GetMouseButtonDown(MOUSE_BUTTON);
	}

	private bool isMousePressed()
	{
		return Input.GetMouseButton(MOUSE_BUTTON);
	}

	private void doMousePressedNowAction()
	{
		updateLastMousePosition();
	}

	private void doMousePressedAction()
	{
		move(getMovementDirection());
		updateLastMousePosition();
	}

	private void updateLastMousePosition()
	{
		lastMousePosition = Input.mousePosition;
	}

	private Vector3 getMovementDirection()
	{
		Vector3 deltaPosition = lastMousePosition - Input.mousePosition;
		float x = deltaPosition.x * directRotationFactor + deltaPosition.y * inverseRotationFactor;
		float z = deltaPosition.y * directRotationFactor - deltaPosition.x * inverseRotationFactor;
		return new Vector3(x, 0, z);
	}

	private void move(Vector3 direction)
	{
		transform.position = getNewPosition(direction * speed);
	}

	private Vector3 getNewPosition(Vector3 delta)
	{
		Vector3 newPosition = transform.position + delta;
		newPosition.x = checkLimits(newPosition.x, startPosition.x);
		newPosition.z = checkLimits(newPosition.z, startPosition.z);
		return newPosition;
	}

	private float checkLimits(float newValue, float startValue)
	{
		if (Mathf.Abs(newValue - startValue) > limit) {
			return startValue + ((newValue > startValue) ? limit : -limit);
		}
		return newValue;
	}
}
