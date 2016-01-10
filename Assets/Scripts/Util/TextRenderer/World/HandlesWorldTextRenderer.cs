using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class HandlesWorldTextRenderer : WorldTextRenderer
{
	private TextFormatter formatter;
	private Vector3 position;

	public HandlesWorldTextRenderer(TextFormatter formatter, Vector3 position)
	{
		this.formatter = formatter;
		this.position = position;
	}

	public void UpdatePosition(Vector3 position)
	{
		this.position = position;
	}

	public void Render()
	{
#if UNITY_EDITOR
		Handles.Label(position, formatter.GetFormattedText());
#endif
	}
}
