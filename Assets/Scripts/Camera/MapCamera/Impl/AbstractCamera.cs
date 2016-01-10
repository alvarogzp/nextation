using UnityEngine;
using System.Collections;

public abstract class AbstractCamera : MapCamera
{
	protected Camera camera;

	public Camera Camera {
		get {
			return camera;
		}
	}

	public virtual void Activate()
	{
		CameraUtils.SetCurrentCamera(camera);
	}

	public virtual void Update()
	{
	}

	public virtual void Deactivate()
	{
	}
}
