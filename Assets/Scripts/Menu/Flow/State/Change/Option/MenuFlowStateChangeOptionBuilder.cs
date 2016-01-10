public class MenuFlowStateChangeOptionBuilder
{
	private MenuFlowStateChangeOptionCondition.Delegate condition;

	public static MenuFlowStateChangeOptionBuilder If(MenuFlowStateChangeOptionCondition.Delegate condition)
	{
		return new MenuFlowStateChangeOptionBuilder() { condition = condition };
	}

	public MenuFlowStateChangeOption To(MenuState to)
	{
		return new MenuFlowStateChangeOption(condition, to);
	}
}
