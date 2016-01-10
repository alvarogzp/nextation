using UnityEngine;
using System.Collections;

public class TranslationMovement : BaseMovement
{
	private Vector3 from;
	private Vector3 to;

	public TranslationMovement(Transform transform, float speed, StepType step, bool terrestrial, Vector3? offset = null)
		: base(transform, speed, step, terrestrial, offset)
	{
	}

	public override void Update(Vector3 to)
	{
		base.Update(to);
		this.from = transform.position;
		this.to = correctDestination(from, to);
		this.duration = calculateDuration(this.from, this.to, speed, step.GetAddedDuration());
	}

	public override void Step()
	{
		base.Step();
		transform.position = Vector3.Lerp(from, to, getStep());
	}

	private float calculateDuration(Vector3 from, Vector3 to, float speed, float addedDuration)
	{
		return Vector3.Distance(from, to) / speed + addedDuration;
	}
}
