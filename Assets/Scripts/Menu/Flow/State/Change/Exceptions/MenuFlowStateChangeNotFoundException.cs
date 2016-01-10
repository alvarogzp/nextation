using System;

public class MenuFlowStateChangeNotFoundException : Exception
{
	public MenuFlowStateChangeNotFoundException(MenuFlowStateChangeDirection direction)
		: base(String.Format("Menu change not found. From: {0:G}. Direction: {1:G}", direction.From, direction.Direction))
	{
	}
}
