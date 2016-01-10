using UnityEngine;
using System.Collections;

public class GuiPlayerPoints
{
	private PlayerPoints data;
	private GuiPlayerPointsTextFormatter textFormatter;

	public PlayerPoints Data {
		get {
			return data;
		}
	}

	public GuiPlayerPoints(PlayerPoints data)
	{
		this.data = data;
		useText(GuiPlayerPointsTextType.None);
	}

	public void useText(GuiPlayerPointsTextType textType)
	{
		textFormatter = GuiPlayerPointsTextFormatterFactory.Get(textType);
		textFormatter.SetData(data);
	}

	public string GetText()
	{
		return textFormatter.GetText();
	}
}
