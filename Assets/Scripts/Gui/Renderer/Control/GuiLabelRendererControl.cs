using UnityEngine;
using System.Collections;

public class GuiLabelRendererControl : GuiRendererControl
{
	public void Render(Rect position, GUIContent content)
	{
		GUI.Label(position, content);
	}

	public Vector2 CalcSize(GUIContent content)
	{
		return GUI.skin.label.CalcSize(content);
	}
}
