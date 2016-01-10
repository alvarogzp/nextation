public class MenuFlowTransitionStates
{
	private MenuState from;
	private MenuState to;

	public MenuState From {
		get {
			return from;
		}
	}
	public MenuState To {
		get {
			return to;
		}
	}

	public MenuFlowTransitionStates(MenuState from, MenuState to)
	{
		this.from = from;
		this.to = to;
	}
}
