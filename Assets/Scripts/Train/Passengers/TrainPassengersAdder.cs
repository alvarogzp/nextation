using UnityEngine;
using System.Collections;

public class TrainPassengersAdder
{
	private int waiting;
	private int available;

	public TrainPassengersAdder SetWaiting(int waiting)
	{
		this.waiting = waiting;
		return this;
	}

	public TrainPassengersAdder SetAvailable(int available)
	{
		this.available = available;
		return this;
	}

	public int GetAdded()
	{
		if (areEnoughAvailable()) {
			return waiting;
		} else {
			return available;
		}
	}

	public int GetLeft()
	{
		if (areEnoughAvailable()) {
			return 0;
		} else {
			return waiting - available;
		}
	}

	private bool areEnoughAvailable()
	{
		return available >= waiting;
	}
}
