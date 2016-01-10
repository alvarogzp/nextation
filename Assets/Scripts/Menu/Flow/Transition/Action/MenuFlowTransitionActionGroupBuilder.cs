public class MenuFlowTransitionActionGroupBuilder
{
	public static MenuFlowTransitionActionGroup Add(MenuFlowTransitionAction action)
	{
		return new MenuFlowTransitionActionGroup().Add(action);
	}
}
