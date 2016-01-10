using UnityEngine;
using System.Collections;

public class RouteUpdateRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	private const string RPC_NAME = RpcCall.ROUTE_UPDATE;

	private Station station;

	public RouteUpdateRpcCallSenderProcessor(Station station)
		: base(RPC_NAME)
	{
		this.station = station;
	}

	public override void Send()
	{
		SendRpc(Builder().With(getStationName()));
	}

	private string getStationName()
	{
		return station.name;
	}
}
