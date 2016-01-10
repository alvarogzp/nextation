using UnityEngine;
using System.Collections;

public class UpCenterHalftLeftGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		Vector2 halfSize = size / 2;
		float left = (Screen.width / 4) - halfSize.x;
		float top = VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
