public class TrainPassengersLimitFactory
{
	public static TrainPassengersLimit Get(TrainPassengersLimitType type)
	{
		switch (type)
		{
		case TrainPassengersLimitType.PerStation:
			return new PerStationTrainPassengersLimit();
		case TrainPassengersLimitType.PerTrain:
			return new PerTrainTrainPassengersLimit();
		default:
			return null;
		}
	}
}
