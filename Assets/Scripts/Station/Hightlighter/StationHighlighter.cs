using UnityEngine;
using System.Collections;

public class StationHighlighter
{
	private const string HIGHLIGHTER_OBJECT_NAME = "HighlightStation";

	private GameObject highlighter;
	private int highlightsCount;

	public StationHighlighter(Vector3 position)
	{
		highlighter = cloneHighlighterTo(position);
		setHighlight(false);
	}

	public void StartHighlight()
	{
		highlightsCount++;
		if (highlightsCount == 1) {
			setHighlight(true);
		}
	}

	public void EndHighlight()
	{
		highlightsCount--;
		if (highlightsCount == 0) {
			setHighlight(false);
		}
	}

	private void setHighlight(bool value)
	{
		if (highlighter) {
			highlighter.SetActive(value);
		}
	}

	private GameObject cloneHighlighterTo(Vector3 position)
	{
		GameObject originalHighlighter = findOriginalHighlighter();
		if (originalHighlighter) {
			return (GameObject) Object.Instantiate(originalHighlighter, position, originalHighlighter.transform.rotation);
		}
		return null;
	}

	private GameObject findOriginalHighlighter()
	{
		return GameObjectFinder.WithName(HIGHLIGHTER_OBJECT_NAME);
	}
}
