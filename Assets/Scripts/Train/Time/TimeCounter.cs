using UnityEngine;

public class TimeCounter
{
	private float startTime;
	private float endTime;
	private bool ended = false;
	private bool started = false;

	public float Elapsed {
		get {
			return elapsedTime();
		}
	}
	public int ElapsedInt {
		get {
			return convertToInt(Elapsed);
		}
	}
	public bool Ended {
		get {
			return ended;
		}
	}

	public void Start()
	{
		startTime = Time.time;
		ended = false;
		started = true;
	}

	public void End()
	{
		endTime = Time.time;
		ended = true;
	}

	private float elapsedTime()
	{
		return getEndTime() - startTime;
	}

	private float getEndTime()
	{
		return (ended || !started) ? endTime : Time.time;
	}

	private int convertToInt(float elapsed)
	{
		return Mathf.FloorToInt(elapsed);
	}
}
