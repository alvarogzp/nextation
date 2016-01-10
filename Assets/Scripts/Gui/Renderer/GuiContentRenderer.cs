using UnityEngine;
using System.Collections;

public class GuiContentRenderer : GuiRenderer
{
	private GuiPosition position;
	private GuiContentRenderer positionReference;

	private GuiPlacement placement;

	public GUIContent Content { get; set; }
	public GuiRendererControl Control { get; set; }

	public GuiContentRenderer()
	{
		Content = new GUIContent();
		Control = new GuiLabelRendererControl();
	}

	public void SetPosition(GuiPosition position, GuiContentRenderer positionReference)
	{
		this.position = position;
		this.positionReference = positionReference;
	}

	public void Render()
	{
		placement = getPlacement();
		Control.Render(placement.Placement, Content);
	}

	private GuiPlacement getPlacement()
	{
		GuiPlacement referencePlacement = positionReference != null ? positionReference.placement : null;
		GuiPositionWithReference positionWithReference = new GuiPositionWithReference(position, referencePlacement);
		return GuiPlacementCalculatorApi.GetPlacement(positionWithReference, contentSize());
	}

	private Vector2 contentSize()
	{
		return Control.CalcSize(Content);
	}
}
