using UnityEngine;
using System.Collections;

public class SelectGameType : BaseOnMouseDownMenu
{
	public GameType GameType;

	void OnMouseDown ()
	{
		store(GameStorageKeys.SelectedGameType, GameType);
		advanceMenuFrom(MenuState.GameTypeSelection);
	}
}
