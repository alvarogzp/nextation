using UnityEngine;
using System.Collections;

public class NetworkTrainRetriever : AbstractTrainRetriever
{
	private Train[] trains;
	private GameStorage<NetworkTrainPlayers> networkTrainsStorage = GameStorageKeys.NetworkTrains;
	private NetworkTrainPlayers networkPlayers;

	public Train[] Trains {
		get {
			return trains;
		}
	}
	public NetworkTrainPlayer[] Players {
		get {
			return networkPlayers != null ? networkPlayers.asArray() : new NetworkTrainPlayer[0];
		}
	}

	public NetworkTrainRetriever(GameObject main)
		: base(main)
	{}

	protected override bool exists()
	{
		return networkTrainsStorage.Exists();
	}

	protected override void retrieve()
	{
		networkPlayers = networkTrainsStorage.Get();
		networkTrainsStorage.Delete();

		trains = networkPlayers.Select(p => p.Train);
	}

	protected override void useDefaultTrain()
	{
		// If no network trains (no network), not use them
		trains = new Train[0];
	}
}
