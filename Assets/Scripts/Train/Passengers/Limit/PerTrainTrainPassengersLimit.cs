public class PerTrainTrainPassengersLimit : AbstractTrainPassengersLimit
{
	public override int GetAvailable(int currentPassengers)
	{
		return limit - currentPassengers;
	}
}
