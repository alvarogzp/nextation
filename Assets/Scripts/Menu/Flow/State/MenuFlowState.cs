public class MenuFlowState
{
	private MenuFlowStateChanger stateChanger;

	private MenuFlowState(MenuState currentState)
	{
		this.stateChanger = MenuFlowStateChanger.From(currentState);
	}

	public static MenuFlowState From(MenuState currentState)
	{
		return new MenuFlowState(currentState);
	}

	public void Advance()
	{
		stateChanger.Direction(MenuFlowStateChangeDirectionType.Forward);
	}

	public void GoBack()
	{
		stateChanger.Direction(MenuFlowStateChangeDirectionType.Backward);
	}
}
