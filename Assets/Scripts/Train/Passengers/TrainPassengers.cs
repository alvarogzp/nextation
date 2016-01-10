public class TrainPassengers
{
	private int currentPassengers;
	private TrainPassengersLimit limit;
	private Player player;

	public int CurrentPassengers {
		get {
			return currentPassengers;
		}
	}

	public TrainPassengers(TrainPassengersLimit limit, Player player)
	{
		this.limit = limit;
		this.player = player;
	}

	public void arrivedAt(Station station)
	{
		int stationPassengers = station.Passengers.Get(player.Train);
		int availablePassengers = limit.GetAvailable(currentPassengers);

		TrainPassengersAdder passengersAdder = new TrainPassengersAdder()
			.SetWaiting(stationPassengers)
			.SetAvailable(availablePassengers);
		int addedPassengers = passengersAdder.GetAdded();

		currentPassengers += addedPassengers;
		station.Passengers.Decrease(player.Train, addedPassengers);

		if (station.Passengers.UpdatesLocal(player)) {
			station.LocalPassengers = passengersAdder.GetLeft();
		}
	}
}
