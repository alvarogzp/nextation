using UnityEngine;
using System.Collections;

public class PlayRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		play(network);
	}

	private void play(RpcNetworkEntity network)
	{
		network.Play();
	}
}
