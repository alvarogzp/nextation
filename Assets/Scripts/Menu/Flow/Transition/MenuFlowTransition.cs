public class MenuFlowTransition
{
	private MenuState currentState;

	private MenuFlowTransition(MenuState currentState)
	{
		this.currentState = currentState;
	}

	public static MenuFlowTransition From(MenuState currentState)
	{
		return new MenuFlowTransition(currentState);
	}

	public void To(MenuState newState)
	{
		MenuFlowTransitionAction action = getTransitionAction(newState);
		action.Perform();
	}

	private MenuFlowTransitionAction getTransitionAction(MenuState newState)
	{
		MenuFlowTransitionStates transitionStates = MenuFlowTransitionStatesBuilder.From(currentState).To(newState);
		return MenuFlowTransitions.GetAction(transitionStates);
	}
}
