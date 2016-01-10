using UnityEngine;

public class SmootherStepType : StepType
{
	public float GetStep(float phase)
	{
		float t = phase;
		return t*t*t * (t * (6f*t - 15f) + 10f);
	}

	public float GetAddedDuration()
	{
		return StepTypeAddedDuration.DOUBLE;
	}
}
