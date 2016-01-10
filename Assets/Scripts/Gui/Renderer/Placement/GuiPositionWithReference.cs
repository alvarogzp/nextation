using UnityEngine;
using System.Collections;

public class GuiPositionWithReference
{
	private GuiPosition position;
	private GuiPlacement reference;

	public GuiPosition Position {
		get {
			return position;
		}
	}

	public GuiPlacement Reference {
		get {
			return reference;
		}
	}

	public GuiPositionWithReference(GuiPosition position, GuiPlacement reference)
	{
		this.position = position;
		this.reference = reference;
	}
}
