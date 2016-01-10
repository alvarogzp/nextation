using UnityEngine;
using System.Collections;

public class CameraUtils
{
	public static void SetCurrentCamera(Camera camera)
	{
		// Trick to set that camera withoud disabling the others
		camera.enabled = false;
		camera.enabled = true;
	}
}
