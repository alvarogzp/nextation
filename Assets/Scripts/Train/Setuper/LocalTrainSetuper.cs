using UnityEngine;
using System.Collections;

public class LocalTrainSetuper : AbstractTrainSetuper
{
	public LocalTrainSetuper(LocalTrainRetriever retriever)
		: base(retriever)
	{}

	public Train Get()
	{
		return ((LocalTrainRetriever) retriever).Train;
	}
}
