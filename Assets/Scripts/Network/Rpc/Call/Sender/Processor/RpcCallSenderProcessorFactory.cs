using UnityEngine;
using System.Collections;

public class RpcCallSenderProcessorFactory
{
	public static RpcCallSenderProcessor MapName()
	{
		return new MapNameRpcCallSenderProcessor();
	}

	public static RpcCallSenderProcessor AddPlayer()
	{
		return new AddPlayerRpcCallSenderProcessor();
	}

	public static RpcCallSenderProcessor RemovePlayer(NetworkPlayer toRemove)
	{
		return new RemovePlayerRpcCallSenderProcessor(toRemove);
	}

	public static RpcCallSenderProcessor Play()
	{
		return Generic(RpcCall.PLAY);
	}

	public static RpcCallSenderProcessor MapLoaded()
	{
		return Generic(RpcCall.MAP_LOADED);
	}

	public static RpcCallSenderProcessor RouteUpdate(Station station)
	{
		return new RouteUpdateRpcCallSenderProcessor(station);
	}

	public static RpcCallSenderProcessor StationPassengers(Station station)
	{
		return new StationPassengersRpcCallSenderProcessor(station);
	}

	public static RpcCallSenderProcessor EndPoints(GamePoints points)
	{
		return new EndPointsRpcCallSenderProcessor(points);
	}

	private static RpcCallSenderProcessor Generic(string name)
	{
		return new GenericRpcCallSenderProcessor(name);
	}
}
