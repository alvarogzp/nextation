using UnityEngine;
using System.Collections;

public class ReducedGuiPlayerPointsTextFormatter : AbstractGuiPlayerPointsTextFormatter
{
	private const string TEXT_COLOR = "orange";
	private static int TEXT_SIZE = Pixels.GetDensityIndependentPixels(20);

	public override string GetText()
	{
		RichTextFormatter formatter = RichTextFormatter.For(data.PlayerName + ": " + data.Points)
			.SetColor(TEXT_COLOR)
			.SetSize(TEXT_SIZE);
		addPointsStatusFormat(formatter);

		return formatter.Format();
	}

	private RichTextFormatter addPointsStatusFormat(RichTextFormatter formatter)
	{
		if (data.Ended) {
			formatter.SetBold();
		}

		return formatter;
	}
}
