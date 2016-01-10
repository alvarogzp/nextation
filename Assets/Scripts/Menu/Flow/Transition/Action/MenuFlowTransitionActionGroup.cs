using System.Collections.Generic;

public class MenuFlowTransitionActionGroup : MenuFlowTransitionAction
{
	private List<MenuFlowTransitionAction> actions = new List<MenuFlowTransitionAction>();

	public MenuFlowTransitionActionGroup()
		: base(MenuFlowTransitionActionType.Group, string.Empty)
	{
	}

	public MenuFlowTransitionActionGroup Add(MenuFlowTransitionAction action)
	{
		actions.Add(action);
		return this;
	}

	public override void Perform()
	{
		foreach (MenuFlowTransitionAction action in actions) {
			action.Perform();
		}
	}
}
