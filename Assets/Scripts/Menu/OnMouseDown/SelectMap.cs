using UnityEngine;
using System.Collections;

public class SelectMap : BaseOnMouseDownMenu
{
	public string MapName;

	void OnMouseDown ()
	{
		store(GameStorageKeys.SelectedMap, MapName);
		advanceMenuFrom(MenuState.MapSelection);
	}
}
