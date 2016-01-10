public class MenuFlowStateChangeOption
{
	private MenuFlowStateChangeOptionCondition.Delegate condition;
	private MenuState to;

	public MenuFlowStateChangeOptionCondition.Delegate Condition {
		get {
			return condition;
		}
	}
	public MenuState To {
		get {
			return to;
		}
	}

	public MenuFlowStateChangeOption(MenuFlowStateChangeOptionCondition.Delegate condition, MenuState to)
	{
		this.condition = condition;
		this.to = to;
	}
}
