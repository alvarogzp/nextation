using UnityEngine;

public class SmoothStepType : StepType
{
	public float GetStep(float phase)
	{
		float t = phase;
		return t*t * (3f - 2f*t);
	}

	public float GetAddedDuration()
	{
		return StepTypeAddedDuration.DOUBLE;
	}
}
