using UnityEngine;
using System.Collections;

public interface GuiRendererControl
{
	void Render(Rect position, GUIContent content);
	Vector2 CalcSize(GUIContent content);
}
