using UnityEngine;
using System.Collections;

public class GuiStaticElement : GuiManagerElement
{
	private GuiContentRenderer guiContentRenderer;

	public GuiStaticElement(GuiContentRenderer renderer)
	{
		guiContentRenderer = renderer;
	}

	public void Render()
	{
		guiContentRenderer.Render();
	}
}
