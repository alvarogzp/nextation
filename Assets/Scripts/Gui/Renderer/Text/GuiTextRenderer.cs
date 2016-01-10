using UnityEngine;
using System.Collections;

public class GuiTextRenderer : GuiContentRenderer
{
	public void SetText(string text)
	{
		Content.text = text;
	}
}
