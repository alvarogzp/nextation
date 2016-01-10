using UnityEngine;
using System.Collections;

public class GuiElementFactory
{
	public static GuiManagerElement GetEndElement(GamePoints maxPoints, GuiRendererControl backToMenuControl, GuiRendererControl showRankingControl)
	{
		GuiTextRenderer mapEndedRenderer = new GuiTextRendererBuilder()
			.WithRichText(RichTextFormatter.For("Mapa finalizado")
				.SetBold()
				.SetColor("lime")
				.SetSize(Pixels.GetDensityIndependentPixels(40))
				.Format())
			.InPosition(GuiPosition.UP_CENTER)
			.Get();

		GuiTextRenderer freeSpaceBetweenButtonsRenderer = new GuiTextRendererBuilder()
			.WithRichText(RichTextFormatter.For("\xa0")
				.SetSize(Pixels.GetDensityIndependentPixels(25))
				.Format())
			.InPosition(GuiPosition.DOWN_CENTER)
			.Get();

		GuiTextRenderer showRankingRenderer = new GuiTextRendererBuilder()
			.WithRichText(RichTextFormatter.For("Ver clasificaci\xf3n")
				.SetBold()
				.SetColor("red")
				.SetSize(Pixels.GetDensityIndependentPixels(25))
				.Format())
			.InPosition(GuiPosition.BEFORE, freeSpaceBetweenButtonsRenderer)
			.WithControl(showRankingControl)
			.Get();

		GuiTextRenderer backToMenuRenderer = new GuiTextRendererBuilder()
			.WithRichText(RichTextFormatter.For("Volver al men\xfa")
				.SetBold()
				.SetColor("cyan")
				.SetSize(Pixels.GetDensityIndependentPixels(25))
				.Format())
			.InPosition(GuiPosition.NEXT, freeSpaceBetweenButtonsRenderer)
			.WithControl(backToMenuControl)
			.Get();

		GuiTextRenderer maxPointsRenderer = new GuiTextRendererBuilder()
			.WithRichText(RichTextFormatter.For("Tu r\x00e9cord: " + maxPoints.Points + " puntos")
				.SetBold()
				.SetColor("cyan")
				.SetSize(Pixels.GetDensityIndependentPixels(20))
				.Format())
			.InPosition(GuiPosition.CENTER_HALF_DOWN)
			.Get();

		return new GuiElementGroup()
			.AddElement(new GuiStaticElement(mapEndedRenderer))
			.AddElement(new GuiStaticElement(freeSpaceBetweenButtonsRenderer))
			.AddElement(new GuiStaticElement(showRankingRenderer))
			.AddElement(new GuiStaticElement(backToMenuRenderer))
			.AddElement(new GuiStaticElement(maxPointsRenderer));
	}

	public static GuiManagerElement GetSwitchCameraElement(string cameraName, GuiPosition position, GuiRendererControl control)
	{
		return new GuiStaticElement(buildFullRenderer(cameraName, "yellow", 15, position, control));
	}

	private static GuiTextRenderer buildFullRenderer(string text, string textColor, int textSize, GuiPosition position, GuiRendererControl control)
	{
		return new GuiTextRendererBuilder()
			.WithRichText(RichTextFormatter.For(text)
				.SetBold()
				.SetColor(textColor)
				.SetSize(Pixels.GetDensityIndependentPixels(textSize))
				.Format())
			.InPosition(position)
			.WithControl(control)
			.Get();
	}
}
