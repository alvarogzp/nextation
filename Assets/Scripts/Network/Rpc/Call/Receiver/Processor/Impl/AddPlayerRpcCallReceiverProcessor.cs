using UnityEngine;
using System.Collections;

public class AddPlayerRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	private const string NETWORK_TRAIN_TAG = "Untagged";

	public override void Process()
	{
		Train train = get<Train>(receivedData.GetDataPart(0));
		addPlayer(train, receivedData.Sender, players);
	}

	private void addPlayer(Train train, NetworkPlayer owner, NetworkTrainPlayers players)
	{
		string newTrainName = RemoteTrainName.GetNameFor(train, owner);
		Train newTrain = clone(train, newTrainName);

		NetworkTrainPlayer player = NetworkTrainPlayerFactory.Create(newTrain, owner);
		players.AddPlayer(player);
	}

	private Train clone(Train train, string newName)
	{
		return GameObjectOperations.To(train.gameObject).Clone(newName).SetTag(NETWORK_TRAIN_TAG).GameObject.GetComponent<Train>();
	}
}
