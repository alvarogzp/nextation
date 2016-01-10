using UnityEngine;
using System.Collections;

public class RpcCallReceiverProcessorFactory
{
	public static RpcCallReceiverProcessor Get(string name)
	{
		switch (name) {
		case RpcCall.MAP_NAME:
			return new MapNameRpcCallReceiverProcessor();
		case RpcCall.ADD_PLAYER:
			return new AddPlayerRpcCallReceiverProcessor();
		case RpcCall.REMOVE_PLAYER:
			return new RemovePlayerRpcCallReceiverProcessor();
		case RpcCall.PLAY:
			return new PlayRpcCallReceiverProcessor();
		case RpcCall.MAP_LOADED:
			return new MapLoadedRpcCallReceiverProcessor();
		case RpcCall.ROUTE_UPDATE:
			return new RouteUpdateRpcCallReceiverProcessor();
		case RpcCall.STATION_PASSENGERS:
			return new StationPassengersRpcCallReceiverProcessor();
		case RpcCall.END_POINTS:
			return new EndPointsRpcCallReceiverProcessor();
		default:
			return new UnknownRpcCallReceiverProcessor();
		}
	}
}
