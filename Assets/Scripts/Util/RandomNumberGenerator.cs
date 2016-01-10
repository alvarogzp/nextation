using UnityEngine;

public class RandomNumberGenerator
{
	/**
	 * @returns Random int in range [min, max-1]
	 */
	public static int GetInt(int min, int max)
	{
		return Random.Range(min, max);
	}
}
