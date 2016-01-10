using UnityEngine;
using System.Collections;

public class LocalTrainConfigurer : AbstractTrainConfigurer
{
	private Train train;

	public LocalTrainConfigurer(LocalTrainRetriever retriever)
		: base(retriever)
	{
		train = retriever.Train;
	}

	public override void Configure()
	{
		if (!isTestTrain()) {
			base.Configure();
			configurate(enableTrainSound);
		}
	}

	private bool isTestTrain()
	{
		return main == train.gameObject;
	}

	protected override void configurate(ConfigurationCall call)
	{
		call(train);
	}
}
