using UnityEngine;
using System.Collections;

public abstract class AbstractRpcCallSenderProcessor : RpcCallSenderProcessor
{
	private static string[] DEFAULT_DATA = new string[0];

	protected string rpcName;

	private NetworkView networkView;
	private RPCMode defaultMode;

	protected AbstractRpcCallSenderProcessor(string rpcName)
	{
		this.rpcName = rpcName;
	}

	public void SetNetworkView(NetworkView networkView)
	{
		this.networkView = networkView;
	}

	public void SetDefaultMode(RPCMode defaultMode)
	{
		this.defaultMode = defaultMode;
	}

	public abstract void Send();

	protected RpcCallSenderBuilder Builder()
	{
		return new RpcCallSenderBuilder(rpcName, DEFAULT_DATA, Network.player, defaultMode);
	}

	protected void SendRpc(RpcCallSenderBuilder builder)
	{
		SendRpc(builder.Build());
	}

	protected void SendRpc(RpcCallSendData sendData)
	{
		logRpcSend(sendData);
		networkView.RPC(NetworkConstants.RPC_NAME, sendData.Mode, sendData.Name, sendData.DataString, sendData.Sender);
	}

	private void logRpcSend(RpcCallSendData sendData)
	{
		Log.Debug("Sending RPC: " + RpcCallFormatter.getDebugName(sendData));
	}
}
