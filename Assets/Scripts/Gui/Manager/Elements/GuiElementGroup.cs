using UnityEngine;
using System.Collections.Generic;

public class GuiElementGroup : GuiManagerElement
{
	private List<GuiManagerElement> elements = new List<GuiManagerElement>();

	public GuiElementGroup AddElement(GuiManagerElement element)
	{
		elements.Add(element);
		return this;
	}

	public void Render()
	{
		elements.ForEach(e => e.Render());
	}
}
