using UnityEngine;
using System.Collections;

public class LoadSelectedMapMenuFlowTransitionActionPerformer : MenuFlowTransitionActionPerformer
{
	public void Perform(string target)
	{
		Application.LoadLevel(getSelectedMap());
	}

	private string getSelectedMap()
	{
		return GameStorageKeys.SelectedMap.Get();
	}
}
