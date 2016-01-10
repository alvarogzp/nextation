public class MenuFlowTransitionActionBuilder
{
	private MenuFlowTransitionActionType action;

	public static MenuFlowTransitionActionBuilder Do(MenuFlowTransitionActionType action)
	{
		return new MenuFlowTransitionActionBuilder() { action = action };
	}

	public MenuFlowTransitionAction On(string target)
	{
		return new MenuFlowTransitionAction(action, target);
	}
}
