using UnityEngine;
using System.Collections;

public class BaseMovement : Movement
{
	protected Transform transform;
	protected float speed;
	protected StepType step;
	private bool terrestrial;
	private Vector3 offset;

	protected float duration;
	private float phase;

	public bool Ended {
		get {
			return phase == 1;
		}
	}

	public BaseMovement(Transform transform, float speed, StepType step, bool terrestrial, Vector3? offset)
	{
		this.transform = transform;
		this.speed = speed;
		this.step = step;
		this.terrestrial = terrestrial;
		this.offset = offset == null ? Vector3.zero : (Vector3) offset;

		this.phase = 1; // Movement start ended
	}

	public virtual void Update(Vector3 to)
	{
		phase = 0;
	}

	public virtual void Step()
	{
		phase += Time.deltaTime / duration;
		if (phase > 1) {
			phase = 1;
		}
	}

	protected float getStep()
	{
		return step.GetStep(phase);
	}

	protected Vector3 correctDestination(Vector3 from, Vector3 to)
	{
		to = to + offset;
		return terrestrial ? new Vector3(to.x, from.y, to.z) : to;
	}
}
