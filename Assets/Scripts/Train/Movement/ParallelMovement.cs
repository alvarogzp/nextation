using UnityEngine;
using System.Collections;

public class ParallelMovement : MovementGroup
{
	public override bool Ended {
		get {
			return allEnded();
		}
	}

	public override void Step()
	{
		foreach (Movement movement in movements) {
			if (!movement.Ended) {
				movement.Step();
			}
		}
	}

	private bool allEnded()
	{
		return movements.TrueForAll(m => m.Ended);
	}
}
