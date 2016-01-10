using UnityEngine;
using System.Collections;

public class UpRightGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		float left = Screen.width - size.x - HORIZONTAL_BORDER_OFFSET;
		float top = VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
