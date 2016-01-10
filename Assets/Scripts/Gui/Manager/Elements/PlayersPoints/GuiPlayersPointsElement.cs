using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiPlayersPointsElement : GuiManagerElement
{
	private const GuiPlayerPointsTextType PLAYING_VIEW = GuiPlayerPointsTextType.None;
	private const GuiPlayerPointsTextType END_VIEW = GuiPlayerPointsTextType.Full;

	private const GuiPosition REDUCED_POSITION = GuiPosition.UP_CENTER;
	private const GuiPosition FULL_POSITION = GuiPosition.CENTER_HALF_UP;

	private static string REDUCED_SEPARATOR = RichTextFormatter.For(" | ")
		.SetBold()
		.SetColor("blue")
		.SetSize(Pixels.GetDensityIndependentPixels(20))
		.Format();

	private List<GuiPlayerPoints> playersPoints = new List<GuiPlayerPoints>();
	private GuiTextRenderer reducedRenderer = new GuiTextRendererBuilder().WithRichText().InPosition(REDUCED_POSITION).Get();
	private GuiTextRenderer[] fullRenderers;
	private string[] reducedTexts = new string[0];
	private GuiPlayerPointsTextType viewType = PLAYING_VIEW;

	public int PlayersCount {
		get {
			return playersPoints.Count;
		}
	}

	public void AddPoints(Player player, CurrentPoints points)
	{
		GuiPlayerPoints element = new GuiPlayerPoints(new PlayerPoints(player, points));
		element.useText(viewType);
		playersPoints.Add(element);
		reducedTexts = new string[reducedTexts.Length+1];
	}

	public void DisplayEndView()
	{
		viewType = END_VIEW;
		playersPoints.ForEach(p => p.useText(viewType));
		setupFullRenderers();
	}

	private void setupFullRenderers()
	{
		GuiTextRenderer[] renderers = new GuiTextRenderer[playersPoints.Count];
		for (int i = 0; i < renderers.Length; i++) {
			renderers[i] = new GuiTextRendererBuilder().WithRichText().Get();
		}
		fullRenderers = renderers;
	}

	public void Render()
	{
		if (viewType != GuiPlayerPointsTextType.None) {
			sortByPoints();
			switch (viewType) {
			case GuiPlayerPointsTextType.Reduced:
				renderReducedView();
				break;
			case GuiPlayerPointsTextType.Full:
				renderFullView();
				break;
			}
		}
	}

	private void sortByPoints()
	{
		playersPoints.Sort(PlayersPointsSorter.ByPoints);
	}

	private void renderReducedView()
	{
		reducedRenderer.SetText(getTexts());
		reducedRenderer.Render();
	}

	private string getTexts()
	{
		for (int i = 0; i < reducedTexts.Length; i++) {
			reducedTexts[i] = playersPoints[i].GetText();
		}
		return string.Join(REDUCED_SEPARATOR, reducedTexts);
	}

	private void renderFullView()
	{
		for (int i = 0; i < fullRenderers.Length; i++) {
			GuiTextRenderer renderer = fullRenderers[i];
			if (i == 0) {
				renderer.SetPosition(FULL_POSITION, null);
			} else {
				renderer.SetPosition(GuiPosition.BELOW, fullRenderers[i-1]);
			}
			renderer.SetText(playersPoints[i].GetText());
			renderer.Render();
		}
	}
}
