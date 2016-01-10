using UnityEngine;
using System.Collections;

public class EndPointsRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		int points = int.Parse(receivedData.GetDataPart(0));
		setEndPoints(Sender, points);
	}

	private void setEndPoints(NetworkTrainPlayer player, int points)
	{
		player.SetEndPoints(new GamePoints(GameMap.MAP_UNKNOWN, points));
	}
}
