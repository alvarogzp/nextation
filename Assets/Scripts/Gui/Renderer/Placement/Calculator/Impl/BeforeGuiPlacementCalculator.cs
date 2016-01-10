using UnityEngine;
using System.Collections;

public class BeforeGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Rect rect = GuiPlacementCalculatorApi.GetPlacement(position.Reference.Position, size).Placement;
		rect.x = position.Reference.Placement.x - size.x;

		return rect;
	}
}
