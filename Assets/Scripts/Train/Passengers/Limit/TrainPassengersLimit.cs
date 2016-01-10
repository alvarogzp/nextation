public interface TrainPassengersLimit
{
	void SetLimit(int limit);
	int GetAvailable(int currentPassengers);
}
