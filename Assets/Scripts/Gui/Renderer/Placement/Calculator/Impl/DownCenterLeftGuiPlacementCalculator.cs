using UnityEngine;
using System.Collections;

public class DownCenterLeftGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		float left = (Screen.width / 2) - size.x;
		float top = Screen.height - size.y - VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
