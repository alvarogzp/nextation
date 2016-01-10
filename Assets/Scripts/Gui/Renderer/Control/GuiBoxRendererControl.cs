using UnityEngine;
using System.Collections;

public class GuiBoxRendererControl : GuiRendererControl
{
	public void Render(Rect position, GUIContent content)
	{
		GUI.Box(position, content);
	}

	public Vector2 CalcSize(GUIContent content)
	{
		return GUI.skin.box.CalcSize(content);
	}
}
