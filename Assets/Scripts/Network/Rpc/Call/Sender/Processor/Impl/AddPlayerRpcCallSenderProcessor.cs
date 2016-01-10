using UnityEngine;
using System.Collections;

public class AddPlayerRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	private const string RPC_NAME = RpcCall.ADD_PLAYER;

	public AddPlayerRpcCallSenderProcessor()
		: base(RPC_NAME)
	{}

	public override void Send()
	{
		SendRpc(Builder().With(getSelectedTrain()));
	}

	private string getSelectedTrain()
	{
		return GameStorageKeys.SelectedTrain.Get();
	}
}
