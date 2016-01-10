public class TrainConfigurerFactory
{
	public static TrainConfigurer Get(TrainRetriever retriever)
	{
		if (retriever is LocalTrainRetriever) {
			return new LocalTrainConfigurer((LocalTrainRetriever) retriever);
		} else if (retriever is NetworkTrainRetriever) {
			return new NetworkTrainConfigurer((NetworkTrainRetriever) retriever);
		}

		return null;
	}
}
