using UnityEngine;
using System.Collections;

public interface RpcCallReceiverProcessor
{
	void SetReceivedData(RpcCallReceivedData receivedData);
	void SetPlayers(NetworkTrainPlayers players);
	void SetNetwork(RpcNetworkEntity network);

	void Process();
}
