public class MenuFlowStateChangeDirectionBuilder
{
	private MenuState from;

	public static MenuFlowStateChangeDirectionBuilder From(MenuState from)
	{
		return new MenuFlowStateChangeDirectionBuilder() { from = from };
	}

	public MenuFlowStateChangeDirection Direction(MenuFlowStateChangeDirectionType direction)
	{
		return new MenuFlowStateChangeDirection(from, direction);
	}
}
