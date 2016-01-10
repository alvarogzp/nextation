using UnityEngine;
using System.Collections;

public class ChangeSceneMenuFlowTransitionActionPerformer : MenuFlowTransitionActionPerformer
{
	public void Perform(string target)
	{
		Application.LoadLevel(target);
	}
}
