using UnityEngine;
using System.Collections;

public class RotationMovement : BaseMovement
{
	private Quaternion from;
	private Quaternion to;

	public RotationMovement(Transform transform, float speed, StepType step, bool terrestrial, Vector3? offset = null)
		: base(transform, speed, step, terrestrial, offset)
	{
	}

	public override void Update(Vector3 to)
	{
		base.Update(to);
		Vector3 fromPosition = transform.position;
		Vector3 toPosition = correctDestination(fromPosition, to);
		Vector3 direction = toPosition - fromPosition;

		this.from = transform.rotation;
		this.to = Quaternion.LookRotation(direction);
		this.duration = calculateDuration(from, this.to, speed, step.GetAddedDuration());
	}

	public override void Step()
	{
		base.Step();
		transform.rotation = Quaternion.Lerp(from, to, getStep());
	}

	private float calculateDuration(Quaternion from, Quaternion to, float speed, float addedDuration)
	{
		return Quaternion.Angle(from, to) / speed + addedDuration;
	}
}
