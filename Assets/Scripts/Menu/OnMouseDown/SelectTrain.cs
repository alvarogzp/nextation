using UnityEngine;
using System.Collections;

public class SelectTrain : BaseOnMouseDownMenu
{
	public Train Train;

	void OnMouseDown ()
	{
		store(GameStorageKeys.SelectedTrain, Train.name);
		advanceMenuFrom(MenuState.TrainSelection);
	}
}
