using UnityEngine;
using System.Collections;

public class CenterDownGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Vector2 halfSize = size / 2;
		float left = (Screen.width / 2) - halfSize.x;
		float top = Screen.height / 2;

		return new Rect(left, top, size.x, size.y);
	}
}
