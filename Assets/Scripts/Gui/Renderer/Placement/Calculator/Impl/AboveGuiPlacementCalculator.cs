using UnityEngine;
using System.Collections;

public class AboveGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Rect rect = GuiPlacementCalculatorApi.GetPlacement(position.Reference.Position, size).Placement;
		rect.y = position.Reference.Placement.y - size.y;

		return rect;
	}
}
