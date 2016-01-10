using UnityEngine;
using System.Collections;

public class RpcCallReceiver
{
	private NetworkTrainPlayers players;
	private RpcNetworkEntity network;

	public RpcCallReceiver(NetworkTrainPlayers players, RpcNetworkEntity network)
	{
		this.players = players;
		this.network = network;
	}

	public RpcCallReceiverProcessor New(string name, string data, NetworkPlayer player, NetworkMessageInfo info)
	{
		string[] dataParts = RpcCallData.GetDataParts(data);
		RpcCallReceivedData receivedData = new RpcCallReceivedData(name, dataParts, player, info);

		logRpcReceived(receivedData);

		return buildProcessor(name, receivedData);
	}

	private void logRpcReceived(RpcCallReceivedData receivedData)
	{
		Log.Debug("Received RPC: " + RpcCallFormatter.getDebugName(receivedData));
	}

	private RpcCallReceiverProcessor buildProcessor(string name, RpcCallReceivedData receivedData)
	{
		RpcCallReceiverProcessor processor = RpcCallReceiverProcessorFactory.Get(name);
		processor.SetReceivedData(receivedData);
		processor.SetPlayers(players);
		processor.SetNetwork(network);

		return processor;
	}
}
