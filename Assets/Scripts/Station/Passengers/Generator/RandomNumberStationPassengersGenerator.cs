using UnityEngine;
using System.Collections;

public class RandomNumberStationPassengersGenerator
{
	private const int MIN_STATION_PASSENGERS = 1;
	private const int MAX_STATION_PASSENGERS = 100;

	public static int GetRandomPassengers()
	{
		return RandomNumberGenerator.GetInt(MIN_STATION_PASSENGERS, MAX_STATION_PASSENGERS);
	}
}
