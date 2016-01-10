using UnityEngine;
using System.Collections;

public class RpcCallSendData : RpcCallData
{
	private RPCMode mode;

	public RPCMode Mode {
		get {
			return mode;
		}
	}

	public RpcCallSendData(string name, string[] data, NetworkPlayer sender, RPCMode mode)
		: base(name, data, sender)
	{
		this.mode = mode;
	}
}
