using UnityEngine;
using System.Collections;

public class DownCenterQuarterRightGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Vector2 halfSize = size / 2;
		float left = (5 * Screen.width / 8) - halfSize.x;
		float top = Screen.height - size.y - VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
