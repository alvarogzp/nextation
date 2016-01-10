using UnityEngine;
using System.Collections;

public class TrainSetuperFactory
{
	private GameObject main;

	public static TrainSetuperFactory On(GameObject main)
	{
		return new TrainSetuperFactory() { main = main };
	}

	public LocalTrainSetuper Local()
	{
		return new LocalTrainSetuper(new LocalTrainRetriever(main));
	}

	public NetworkTrainSetuper Network()
	{
		return new NetworkTrainSetuper(new NetworkTrainRetriever(main));
	}
}
