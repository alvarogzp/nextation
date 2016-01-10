using UnityEngine;
using System.Collections;

public class GuiHudElement : GuiManagerElement
{
	private static readonly int DATA_TEXT_SIZE = Pixels.GetDensityIndependentPixels(25);

	private TrainPassengers passengers;
	private TimeCounter timeCounter;

	private GuiTextRenderer leftGuiTextRenderer = new GuiTextRendererBuilder()
		.WithRichText()
		.InPosition(GuiPosition.UP_LEFT)
		.WithControl(new GuiBoxRendererControl())
		.Get();
	private GuiTextRenderer rightGuiTextRenderer =  new GuiTextRendererBuilder()
		.WithRichText()
		.InPosition(GuiPosition.UP_RIGHT)
		.WithControl(new GuiBoxRendererControl())
		.Get();

	public GuiHudElement(TrainPassengers passengers, TimeCounter timeCounter)
	{
		this.passengers = passengers;
		this.timeCounter = timeCounter;
	}

	public void Render()
	{
		//                                                                   ☺
		leftGuiTextRenderer.SetText("<size=" + DATA_TEXT_SIZE + "><b><color=white>\u263A " + passengers.CurrentPassengers + "</color></b></size>");
		leftGuiTextRenderer.Render();

		//                                                                  ⏰
		rightGuiTextRenderer.SetText("<size=" + DATA_TEXT_SIZE + "><b><color=red>\u23F0 " + timeCounter.ElapsedInt + "</color></b></size>");
		rightGuiTextRenderer.Render();
	}
}
