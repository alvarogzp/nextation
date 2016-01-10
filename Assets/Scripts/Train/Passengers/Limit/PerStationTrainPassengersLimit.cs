public class PerStationTrainPassengersLimit : AbstractTrainPassengersLimit
{
	public override int GetAvailable(int currentPassengers)
	{
		return limit;
	}
}
