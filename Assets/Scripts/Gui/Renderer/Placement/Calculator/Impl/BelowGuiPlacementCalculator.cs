using UnityEngine;
using System.Collections;

public class BelowGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Rect rect = GuiPlacementCalculatorApi.GetPlacement(position.Reference.Position, size).Placement;
		rect.y = position.Reference.Placement.y + position.Reference.Placement.height;

		return rect;
	}
}
