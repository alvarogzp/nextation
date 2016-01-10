using UnityEngine;
using System.Collections;

public class GenericRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	public GenericRpcCallSenderProcessor(string name)
		: base(name)
	{}

	public override void Send()
	{
		SendRpc(Builder());
	}
}
