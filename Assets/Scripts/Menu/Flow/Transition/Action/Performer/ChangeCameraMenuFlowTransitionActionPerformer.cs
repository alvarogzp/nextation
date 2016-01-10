using UnityEngine;
using System.Collections;

public class ChangeCameraMenuFlowTransitionActionPerformer : AbstractComponentMenuFlowTransitionActionPerformer
{
	public override void Perform(string target)
	{
		Camera camera = get<Camera>(target);
		CameraUtils.SetCurrentCamera(camera);
	}
}
