using UnityEngine;
using System.Collections;

public abstract class AbstractGuiPlayerPointsTextFormatter : GuiPlayerPointsTextFormatter
{
	protected PlayerPoints data;

	public void SetData(PlayerPoints data)
	{
		this.data = data;
	}

	public abstract string GetText();
}
