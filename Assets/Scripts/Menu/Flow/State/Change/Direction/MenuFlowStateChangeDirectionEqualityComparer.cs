using System.Collections.Generic;

public class MenuFlowStateChangeDirectionEqualityComparer : EqualityComparer<MenuFlowStateChangeDirection>
{
	public override bool Equals(MenuFlowStateChangeDirection o1, MenuFlowStateChangeDirection o2)
	{
		return o1.From == o2.From && o1.Direction == o2.Direction;
	}

	public override int GetHashCode(MenuFlowStateChangeDirection o)
	{
		return (((int) o.From) << 8) + ((int) o.Direction);
	}
}
