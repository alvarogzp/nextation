using UnityEngine;
using System.Collections;

public class DefaultGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		return new Rect();
	}
}
