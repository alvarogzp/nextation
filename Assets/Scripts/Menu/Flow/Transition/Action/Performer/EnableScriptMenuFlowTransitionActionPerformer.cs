using UnityEngine;
using System.Collections;

public class EnableScriptMenuFlowTransitionActionPerformer : AbstractComponentMenuFlowTransitionActionPerformer
{
	public override void Perform(string target)
	{
		MonoBehaviour script = get<MonoBehaviour>(target);
		enable(script);
	}

	private void enable(MonoBehaviour script)
	{
		script.enabled = true;
	}
}
