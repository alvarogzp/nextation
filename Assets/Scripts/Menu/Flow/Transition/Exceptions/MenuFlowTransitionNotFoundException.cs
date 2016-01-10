using System;

public class MenuFlowTransitionNotFoundException : Exception
{
	public MenuFlowTransitionNotFoundException(MenuFlowTransitionStates states)
		: base(String.Format("Menu transition not found. From: {0:G} -> To: {1:G}", states.From, states.To))
	{
	}
}
