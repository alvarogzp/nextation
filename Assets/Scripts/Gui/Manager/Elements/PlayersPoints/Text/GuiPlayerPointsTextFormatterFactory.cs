using UnityEngine;
using System.Collections;

public class GuiPlayerPointsTextFormatterFactory
{
	public static GuiPlayerPointsTextFormatter Get(GuiPlayerPointsTextType type)
	{
		switch (type) {
		case GuiPlayerPointsTextType.None:
			return new NoneGuiPlayerPointsTextFormatter();
		case GuiPlayerPointsTextType.Reduced:
			return new ReducedGuiPlayerPointsTextFormatter();
		case GuiPlayerPointsTextType.Full:
			return new FullGuiPlayerPointsTextFormatter();
		default:
			return null;
		}
	}
}
