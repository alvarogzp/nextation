using UnityEngine;
using System.Collections;

public class RpcCallReceivedData : RpcCallData
{
	private NetworkMessageInfo info;

	public NetworkMessageInfo Info {
		get {
			return info;
		}
	}

	public RpcCallReceivedData(string name, string[] data, NetworkPlayer sender, NetworkMessageInfo info)
		: base(name, data, sender)
	{
		this.info = info;
	}
}
