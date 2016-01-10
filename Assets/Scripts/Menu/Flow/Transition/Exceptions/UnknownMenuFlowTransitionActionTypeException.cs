using System;

public class UnknownMenuFlowTransitionActionTypeException : Exception
{
	public UnknownMenuFlowTransitionActionTypeException(MenuFlowTransitionActionType type)
		: base(String.Format("Unknown transition type: {0:G}", type))
	{
	}
}
