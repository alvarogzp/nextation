using UnityEngine;
using System.Collections;

public class DisableScriptMenuFlowTransitionActionPerformer : AbstractComponentMenuFlowTransitionActionPerformer
{
	public override void Perform(string target)
	{
		MonoBehaviour script = get<MonoBehaviour>(target);
		disable(script);
	}

	private void disable(MonoBehaviour script)
	{
		script.enabled = false;
	}
}
