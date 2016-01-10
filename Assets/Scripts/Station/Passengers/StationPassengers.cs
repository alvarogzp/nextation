public interface StationPassengers
{
	void SetInitial(int passengers);

	int Get(Train train);
	void Decrease(Train train, int passengersToDecrease);

	bool UpdatesLocal(Player player);
}
