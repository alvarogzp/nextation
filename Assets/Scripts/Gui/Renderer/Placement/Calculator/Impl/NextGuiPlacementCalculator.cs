using UnityEngine;
using System.Collections;

public class NextGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Rect rect = GuiPlacementCalculatorApi.GetPlacement(position.Reference.Position, size).Placement;
		rect.x = position.Reference.Placement.x + position.Reference.Placement.width;

		return rect;
	}
}
