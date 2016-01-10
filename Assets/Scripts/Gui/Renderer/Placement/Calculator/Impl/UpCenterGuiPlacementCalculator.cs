using UnityEngine;
using System.Collections;

public class UpCenterGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Vector2 halfSize = size / 2;
		float left = (Screen.width / 2) - halfSize.x;
		float top = VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
