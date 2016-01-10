using UnityEngine;

public interface GuiPlacementCalculator
{
	GuiPlacementCalculator For(GuiPositionWithReference position);
	GuiPlacementCalculator With(Vector2 size);
	GuiPlacement GetPlacement();
}
