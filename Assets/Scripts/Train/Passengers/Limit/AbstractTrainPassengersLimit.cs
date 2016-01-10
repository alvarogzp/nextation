public abstract class AbstractTrainPassengersLimit : TrainPassengersLimit
{
	protected int limit;

	public void SetLimit(int limit)
	{
		this.limit = limit;
	}

	public abstract int GetAvailable(int currentPassengers);
}
