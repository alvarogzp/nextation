using UnityEngine;
using System.Collections;

public class GuiManager
{
	private GuiElementGroup guiElements = new GuiElementGroup();

	public void AddElement(GuiManagerElement guiElement)
	{
		guiElements.AddElement(guiElement);
	}

	public void Render()
	{
		guiElements.Render();
	}
}
