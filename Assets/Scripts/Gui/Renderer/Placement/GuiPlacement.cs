using UnityEngine;
using System.Collections;

public class GuiPlacement
{
	private GuiPositionWithReference position;
	private Rect placement;

	public GuiPositionWithReference Position {
		get {
			return position;
		}
	}

	public Rect Placement {
		get {
			return placement;
		}
	}

	public GuiPlacement(GuiPositionWithReference position, Rect placement)
	{
		this.position = position;
		this.placement = placement;
	}
}
