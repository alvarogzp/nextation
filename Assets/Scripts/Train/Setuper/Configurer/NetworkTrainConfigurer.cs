using UnityEngine;
using System.Collections;

public class NetworkTrainConfigurer : AbstractTrainConfigurer
{
	private Train[] trains;
	private GameObject originalMain;

	public NetworkTrainConfigurer(NetworkTrainRetriever retriever)
		: base(retriever)
	{
		trains = retriever.Trains;
		originalMain = main;
	}

	protected override void configurate(ConfigurationCall call)
	{
		foreach (Train train in trains) {
			call(train);
		}
	}

	protected override void gameObjectOperations(Train train)
	{
		main = new GameObject(originalMain.name + "@" + train.name.Split('@')[1]);
		GameObjectOperations.To(main).SetPosition(originalMain);
		base.gameObjectOperations(train);
	}
}
