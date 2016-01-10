using System.Collections.Generic;

public class PerTrainStationPassengers : StationPassengers
{
	private int initialPassengers;
	private Dictionary<Train, int> passengersPerTrain = new Dictionary<Train, int>();

	public void SetInitial(int passengers)
	{
		initialPassengers = passengers;
		passengersPerTrain.Clear();
	}

	public int Get(Train train)
	{
		return isSet(train) ? passengersPerTrain[train] : initialPassengers;
	}

	public void Decrease(Train train, int passengersToDecrease)
	{
		if (!isSet(train)) {
			passengersPerTrain[train] = initialPassengers;
		}
		passengersPerTrain[train] -= passengersToDecrease;
	}

	private bool isSet(Train train)
	{
		return passengersPerTrain.ContainsKey(train);
	}

	public bool UpdatesLocal(Player player)
	{
		return player.IsLocal;
	}
}
