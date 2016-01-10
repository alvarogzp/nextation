using System;

public class NoApplicableOptionFoundForMenuFlowStateChangeDirectionException : Exception
{
	public NoApplicableOptionFoundForMenuFlowStateChangeDirectionException(MenuFlowStateChangeDirection direction)
		: base(String.Format("No applicable option found for menu change. From: {0:G}. Direction: {1:G}", direction.From, direction.Direction))
	{
	}
}
