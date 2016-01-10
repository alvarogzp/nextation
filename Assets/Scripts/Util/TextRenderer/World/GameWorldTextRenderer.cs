using UnityEngine;
using System.Collections;

public class GameWorldTextRenderer : WorldTextRenderer
{
	private TextFormatter formatter;
	private GameObject gameObject;
	private TextMesh textMesh;

	public GameWorldTextRenderer(TextFormatter formatter, Vector3 position)
	{
		this.formatter = formatter;

		gameObject = new GameObject(tagName(formatter.GetId()));
		UpdatePosition(position);

		textMesh = gameObject.AddComponent<TextMesh>();
		textMesh.fontSize = (int) (100 * GameMapSizeFactor.GetFactorForCurrentMapRelativeToFirstMap());
		textMesh.anchor = TextAnchor.UpperCenter;
		textMesh.alignment = TextAlignment.Center;
		textMesh.color = Color.yellow;
		textMesh.fontStyle = FontStyle.Bold;
	}

	public void UpdatePosition(Vector3 position)
	{
		gameObject.transform.position = position;
		gameObject.transform.rotation = Camera.main.transform.rotation;
	}

	public void Render()
	{
		textMesh.text = formatter.GetFormattedText();
	}

	private string tagName(string text)
	{
		return "TextTag" + text;
	}
}
