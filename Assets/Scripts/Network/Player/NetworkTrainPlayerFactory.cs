using UnityEngine;
using System.Collections;

public class NetworkTrainPlayerFactory
{
	public static NetworkTrainPlayer Create(Train train, NetworkPlayer networkPlayer)
	{
		return new NetworkTrainPlayer(train, networkPlayer);
	}
}
