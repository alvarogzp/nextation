using UnityEngine;
using System.Collections;

public class UpLeftGuiPlacementCalculator : AbstractGuiPlacementCalculator
{
	protected override Rect placement()
	{
		float left = HORIZONTAL_BORDER_OFFSET;
		float top = VERTICAL_BORDER_OFFSET;

		return new Rect(left, top, size.x, size.y);
	}
}
