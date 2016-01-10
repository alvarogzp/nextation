public interface StepType
{
	/**
	 * Given a linear phase between 0 and 1 returns a float also between 0 and 1
	 * given a formula that might be non-linear, generating different kind of movements.
	 */
	float GetStep(float phase);

	/**
	 * Constant duration that this step type adds to the movement
	 * (because of acceleration and deceleration, for example).
	 */
	float GetAddedDuration();
}
