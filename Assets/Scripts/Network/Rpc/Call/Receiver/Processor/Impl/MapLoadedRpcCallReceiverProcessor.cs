using UnityEngine;
using System.Collections;

public class MapLoadedRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		mapLoaded(Sender);
	}

	private void mapLoaded(NetworkTrainPlayer player)
	{
		player.MapLoaded();
	}
}
