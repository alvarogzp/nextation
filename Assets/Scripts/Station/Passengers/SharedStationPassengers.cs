public class SharedStationPassengers : StationPassengers
{
	private int passengers;

	public void SetInitial(int passengers)
	{
		this.passengers = passengers;
	}

	public int Get(Train train)
	{
		return passengers;
	}

	public void Decrease(Train train, int passengersToDecrease)
	{
		passengers -= passengersToDecrease;
	}

	public bool UpdatesLocal(Player player)
	{
		return true;
	}
}
