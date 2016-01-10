using UnityEngine;
using System;
using System.Collections;

public class GuiButtonRendererControl : GuiRendererControl
{
	private bool pressed;
	private Action action;

	public GuiButtonRendererControl(Action action)
	{
		this.action = action;
	}

	public void Render(Rect position, GUIContent content)
	{
		bool pressed = GUI.Button(position, content);
		if (pressed) {
			this.pressed = true;
		}
	}

	public Vector2 CalcSize(GUIContent content)
	{
		return GUI.skin.button.CalcSize(content);
	}

	public void Check()
	{
		if (isPressed()) {
			resetPressedStatus();
			action();
		}
	}

	private bool isPressed()
	{
		return pressed;
	}

	private void resetPressedStatus()
	{
		pressed = false;
	}
}
