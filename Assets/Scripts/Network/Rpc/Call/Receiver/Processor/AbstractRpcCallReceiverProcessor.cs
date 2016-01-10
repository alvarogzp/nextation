using UnityEngine;
using System.Collections;

public abstract class AbstractRpcCallReceiverProcessor : RpcCallReceiverProcessor
{
	protected RpcCallReceivedData receivedData;
	protected NetworkTrainPlayers players;
	protected RpcNetworkEntity network;

	protected NetworkTrainPlayer Sender {
		get {
			return players.GetPlayer(receivedData.Sender);
		}
	}

	public void SetReceivedData(RpcCallReceivedData receivedData)
	{
		this.receivedData = receivedData;
	}

	public void SetPlayers(NetworkTrainPlayers players)
	{
		this.players = players;
	}

	public void SetNetwork(RpcNetworkEntity network)
	{
		this.network = network;
	}

	public abstract void Process();

	protected T get<T>(string name)
	{
		return GameObjectFinder.WithName<T>(name);
	}
}
