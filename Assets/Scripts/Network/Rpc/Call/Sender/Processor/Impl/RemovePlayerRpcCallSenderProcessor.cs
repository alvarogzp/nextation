using UnityEngine;
using System.Collections;

public class RemovePlayerRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	private const string RPC_NAME = RpcCall.REMOVE_PLAYER;

	private NetworkPlayer toRemove;

	public RemovePlayerRpcCallSenderProcessor(NetworkPlayer toRemove)
		: base(RPC_NAME)
	{
		this.toRemove = toRemove;
	}

	public override void Send()
	{
		SendRpc(Builder().As(toRemove).ToAll());
	}
}
