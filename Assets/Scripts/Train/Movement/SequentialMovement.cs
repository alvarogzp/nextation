using UnityEngine;
using System.Collections;

public class SequentialMovement : MovementGroup
{
	public override bool Ended {
		get {
			return last().Ended;
		}
	}

	public override void Step()
	{
		foreach (Movement movement in movements) {
			if (!movement.Ended) {
				movement.Step();
				break;
			}
		}
	}

	private Movement last()
	{
		return movements[movements.Count-1];
	}
}
