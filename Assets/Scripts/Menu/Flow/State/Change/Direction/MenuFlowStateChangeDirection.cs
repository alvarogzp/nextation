public class MenuFlowStateChangeDirection
{
	private MenuState from;
	private MenuFlowStateChangeDirectionType direction;

	public MenuState From {
		get {
			return from;
		}
	}
	public MenuFlowStateChangeDirectionType Direction {
		get {
			return direction;
		}
	}

	public MenuFlowStateChangeDirection(MenuState from, MenuFlowStateChangeDirectionType direction)
	{
		this.from = from;
		this.direction = direction;
	}
}
