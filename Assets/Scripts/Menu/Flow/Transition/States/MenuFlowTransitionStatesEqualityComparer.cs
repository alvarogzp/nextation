using System.Collections.Generic;

public class MenuFlowTransitionStatesEqualityComparer : EqualityComparer<MenuFlowTransitionStates>
{
	public override bool Equals(MenuFlowTransitionStates o1, MenuFlowTransitionStates o2)
	{
		return o1.From == o2.From && o1.To == o2.To;
	}

	public override int GetHashCode(MenuFlowTransitionStates o)
	{
		return (((int) o.From) << 8) + ((int) o.To);
	}
}
