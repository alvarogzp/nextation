using UnityEngine;
using System.Collections;

public class CenterHalfUpGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Vector2 halfSize = size / 2;
		float left = (Screen.width / 2) - halfSize.x;
		float top = (Screen.height / 4) - halfSize.y;

		return new Rect(left, top, size.x, size.y);
	}
}
