using UnityEngine;
using System.Collections.Generic;

public abstract class MovementGroup : Movement
{
	public abstract bool Ended { get; }

	protected List<Movement> movements = new List<Movement>();

	public MovementGroup AddMovement(Movement movement)
	{
		movements.Add(movement);
		return this;
	}

	public void Update(Vector3 to)
	{
		movements.ForEach(m => m.Update(to));
	}

	public abstract void Step();
}
