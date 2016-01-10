using UnityEngine;
using System.Collections;

public class NetworkTrainSetuper : AbstractTrainSetuper
{
	public NetworkTrainSetuper(NetworkTrainRetriever retriever)
		: base(retriever)
	{}

	public NetworkTrainPlayer[] Get()
	{
		return ((NetworkTrainRetriever) retriever).Players;
	}
}
