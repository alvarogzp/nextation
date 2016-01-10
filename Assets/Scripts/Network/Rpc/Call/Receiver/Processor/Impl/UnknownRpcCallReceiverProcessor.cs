using UnityEngine;
using System.Collections;

public class UnknownRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		// Do not throw an exception or fail when receiving unknown RPCs to ease integration
		// in case there are other players using a newer versions of the game with new RPCs
		Log.Warn("Ignoring unknown RPC received: " + receivedData.Name);
	}
}
