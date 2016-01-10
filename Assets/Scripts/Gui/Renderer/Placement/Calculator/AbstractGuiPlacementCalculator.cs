using UnityEngine;
using System.Collections;

public abstract class AbstractGuiPlacementCalculator : GuiPlacementCalculator
{
	protected static int HORIZONTAL_BORDER_OFFSET = Pixels.GetDensityIndependentPixels(10);
	protected static int VERTICAL_BORDER_OFFSET = Pixels.GetDensityIndependentPixels(5);

	protected GuiPositionWithReference position;
	protected Vector2 size;

	public GuiPlacementCalculator For(GuiPositionWithReference position)
	{
		this.position = position;
		return this;
	}

	public GuiPlacementCalculator With(Vector2 size)
	{
		this.size = size;
		return this;
	}

	public GuiPlacement GetPlacement()
	{
		return new GuiPlacement(position, placement());
	}

	protected abstract Rect placement();
}
