using UnityEngine;
using System.Collections;

public class MenuFlow : MonoBehaviour
{
	public MenuState CurrentState;
	public MenuAction Action;

	void OnMouseDown ()
	{
		MenuFlowState menuFlowState = MenuFlowState.From(CurrentState);

		switch (Action) {
		case MenuAction.Advance:
			menuFlowState.Advance();
			break;
		case MenuAction.GoBack:
			menuFlowState.GoBack();
			break;
		}
	}
}
