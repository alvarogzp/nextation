using UnityEngine;
using System.Collections;

public class DownRightGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		float left = Screen.width - size.x - HORIZONTAL_BORDER_OFFSET;
		float top = Screen.height - size.y - VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
