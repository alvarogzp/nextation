using UnityEngine;
using System.Collections;

public class RouteUpdateRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		Station station = get<Station>(receivedData.GetDataPart(0));
		routeUpdate(Sender, station);
	}

	private void routeUpdate(NetworkTrainPlayer player, Station nextStation)
	{
		player.AddToRoute(nextStation);
	}
}
