public class MenuFlowTransitionAction
{
	private MenuFlowTransitionActionType type;
	private string target;

	public MenuFlowTransitionAction(MenuFlowTransitionActionType type, string target)
	{
		this.type = type;
		this.target = target;
	}

	public virtual void Perform()
	{
		MenuFlowTransitionActionPerformerFactory.For(type).Perform(target);
	}
}
