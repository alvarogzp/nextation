using UnityEngine;
using System.Collections;

public class CurrentPoints
{
	private GameMap map;
	private TrainPassengers passengers;
	private TimeCounter timeCounter;

	public GameMap Map {
		get {
			return map;
		}
	}
	public int Passengers {
		get {
			return passengers.CurrentPassengers;
		}
	}
	public int Time {
		get {
			return timeCounter.ElapsedInt;
		}
	}
	public int IntPoints {
		get {
			return convertToInt(calculatePoints());
		}
	}
	public bool Ended {
		get {
			return timeCounter.Ended;
		}
	}

	public CurrentPoints(GameMap map, TrainPassengers passengers, TimeCounter timeCounter)
	{
		this.map = map;
		this.passengers = passengers;
		this.timeCounter = timeCounter;
	}

	public GamePoints GetPoints()
	{
		return new GamePoints(map, IntPoints);
	}

	private float calculatePoints()
	{
		return Passengers - (timeCounter.Elapsed * 5);
	}

	private int convertToInt(float points)
	{
		return Mathf.FloorToInt(points);
	}
}
