using UnityEngine;
using System.Collections.Generic;

public class CameraManager
{
	private MapCamera currentCamera;

	public Camera Current {
		get {
			return currentCamera.Camera;
		}
	}

	public CameraManager(MapCamera initialCamera)
	{
		setCurrentCamera(initialCamera);
	}

	private void setCurrentCamera(MapCamera camera)
	{
		currentCamera = camera;
		currentCamera.Activate();
	}

	public void Update()
	{
		currentCamera.Update();
	}

	public void SetCamera(MapCamera camera)
	{
		currentCamera.Deactivate();
		setCurrentCamera(camera);
	}
}
