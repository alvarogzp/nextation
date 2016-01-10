using UnityEngine;
using System.Collections;

public class MapNameRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	private const string RPC_NAME = RpcCall.MAP_NAME;

	public MapNameRpcCallSenderProcessor()
		: base(RPC_NAME)
	{}

	public override void Send()
	{
		SendRpc(Builder().With(getSelectedMap()));
	}

	private string getSelectedMap()
	{
		return GameStorageKeys.SelectedMap.Get();
	}
}
