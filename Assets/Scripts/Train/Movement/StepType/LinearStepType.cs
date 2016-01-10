using UnityEngine;

public class LinearStepType : StepType
{
	public float GetStep(float phase)
	{
		return phase;
	}

	public float GetAddedDuration()
	{
		return StepTypeAddedDuration.NONE;
	}
}
