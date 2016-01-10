using UnityEngine;
using System.Collections;

public class GizmosRailRenderer : RailRenderer
{
	public void Render(Station from, Station to)
	{
		Vector3 fromPosition = from.transform.position;
		Vector3 toPosition = to.transform.position;
		Vector3 direction = toPosition - fromPosition;
		float headLength = 20f * GameMapSizeFactor.GetFactorForCurrentMapRelativeToFirstMap();

		DrawArrow.ForGizmo(fromPosition, direction, headLength);
	}
}
