using UnityEngine;
using System.Collections;

public class GuiTextRendererBuilder
{
	private GuiTextRenderer renderer = new GuiTextRenderer();

	public GuiTextRendererBuilder WithText(string text)
	{
		renderer.SetText(text);
		return this;
	}

	public GuiTextRendererBuilder WithRichText(string text = "")
	{
		return WithText(text);
	}

	public GuiTextRendererBuilder InPosition(GuiPosition position, GuiContentRenderer reference = null)
	{
		renderer.SetPosition(position, reference);
		return this;
	}

	public GuiTextRendererBuilder WithControl(GuiRendererControl control)
	{
		renderer.Control = control;
		return this;
	}

	public GuiTextRenderer Get()
	{
		return renderer;
	}
}
