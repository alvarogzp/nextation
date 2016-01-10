using UnityEngine;

public class LinearWithSlowEndStepType : StepType
{
	public float GetStep(float phase)
	{
		float t = phase;
		return Mathf.Sin(t * Mathf.PI * 0.5f);
	}

	public float GetAddedDuration()
	{
		return StepTypeAddedDuration.SIMPLE;
	}
}
