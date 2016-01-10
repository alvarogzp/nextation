using UnityEngine;
using System.Collections;

public class SelectMultiplayerRole : BaseOnMouseDownMenu
{
	public MultiplayerRole MultiplayerRole;

	void OnMouseDown ()
	{
		store(GameStorageKeys.SelectedMultiplayerRole, MultiplayerRole);
		advanceMenuFrom(MenuState.MultiplayerRoleSelection);
	}
}
