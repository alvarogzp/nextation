using UnityEngine;
using System.Collections;

public class RpcCallSender
{
	private NetworkView networkView;
	private RPCMode defaultMode;

	public RpcCallSender(NetworkView networkView)
	{
		this.networkView = networkView;
	}

	public RpcCallSender DefaultToAll()
	{
		defaultMode = RPCMode.AllBuffered;
		return this;
	}

	public RpcCallSender DefaultToOthers()
	{
		defaultMode = RPCMode.OthersBuffered;
		return this;
	}

	public void MapName()
	{
		setupAndSend(RpcCallSenderProcessorFactory.MapName());
	}

	public void AddPlayer()
	{
		setupAndSend(RpcCallSenderProcessorFactory.AddPlayer());
	}

	public void RemovePlayer(NetworkPlayer toRemove)
	{
		setupAndSend(RpcCallSenderProcessorFactory.RemovePlayer(toRemove));
	}

	public void Play()
	{
		setupAndSend(RpcCallSenderProcessorFactory.Play());
	}

	public void MapLoaded()
	{
		setupAndSend(RpcCallSenderProcessorFactory.MapLoaded());
	}

	public void RouteUpdate(Station station)
	{
		setupAndSend(RpcCallSenderProcessorFactory.RouteUpdate(station));
	}

	public void StationPassengers(Station station)
	{
		setupAndSend(RpcCallSenderProcessorFactory.StationPassengers(station));
	}

	public void EndPoints(GamePoints points)
	{
		setupAndSend(RpcCallSenderProcessorFactory.EndPoints(points));
	}

	private void setupAndSend(RpcCallSenderProcessor processor)
	{
		setup(processor).Send();
	}

	private RpcCallSenderProcessor setup(RpcCallSenderProcessor processor)
	{
		processor.SetNetworkView(networkView);
		processor.SetDefaultMode(defaultMode);
		return processor;
	}
}
