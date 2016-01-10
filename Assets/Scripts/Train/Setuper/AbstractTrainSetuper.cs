using UnityEngine;
using System.Collections;

public abstract class AbstractTrainSetuper : TrainSetuper
{
	protected TrainRetriever retriever;

	public AbstractTrainSetuper(TrainRetriever retriever)
	{
		this.retriever = retriever;
	}

	public void Setup()
	{
		retriever.Retrieve();
		getConfigurer().Configure();
	}

	private TrainConfigurer getConfigurer()
	{
		return TrainConfigurerFactory.Get(retriever);
	}
}
