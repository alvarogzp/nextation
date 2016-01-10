using UnityEngine;
using System.Collections;

public class RpcCallSenderBuilder
{
	private string name;
	private string[] data;
	private NetworkPlayer sender;
	private RPCMode mode;

	public RpcCallSenderBuilder(string name, string[] defaultData, NetworkPlayer defaultSender, RPCMode defaultMode)
	{
		this.name = name;
		this.data = defaultData;
		this.sender = defaultSender;
		this.mode = defaultMode;
	}

	public RpcCallSenderBuilder With(params string[] data)
	{
		this.data = data;
		return this;
	}

	public RpcCallSenderBuilder As(NetworkPlayer sender)
	{
		this.sender = sender;
		return this;
	}

	public RpcCallSenderBuilder ToAll()
	{
		this.mode = RPCMode.AllBuffered;
		return this;
	}

	public RpcCallSenderBuilder ToOthers()
	{
		this.mode = RPCMode.OthersBuffered;
		return this;
	}

	public RpcCallSendData Build()
	{
		return new RpcCallSendData(name, data, sender, mode);
	}
}
