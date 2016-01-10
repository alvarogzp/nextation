using UnityEngine;
using System.Collections;

public interface RpcCallSenderProcessor
{
	void SetNetworkView(NetworkView networkView);
	void SetDefaultMode(RPCMode defaultMode);

	void Send();
}
