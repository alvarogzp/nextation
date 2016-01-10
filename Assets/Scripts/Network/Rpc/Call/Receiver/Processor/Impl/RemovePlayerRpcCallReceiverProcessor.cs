using UnityEngine;
using System.Collections;

public class RemovePlayerRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		removePlayer(players, receivedData.Sender);
	}

	private void removePlayer(NetworkTrainPlayers players, NetworkPlayer player)
	{
		players.RemovePlayer(players.GetPlayer(player));
	}
}
