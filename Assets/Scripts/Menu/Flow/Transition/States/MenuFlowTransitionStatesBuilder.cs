public class MenuFlowTransitionStatesBuilder
{
	private MenuState from;

	public static MenuFlowTransitionStatesBuilder From(MenuState from)
	{
		return new MenuFlowTransitionStatesBuilder() { from = from };
	}

	public MenuFlowTransitionStates To(MenuState to)
	{
		return new MenuFlowTransitionStates(from, to);
	}
}
