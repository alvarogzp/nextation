using UnityEngine;
using System.Collections;

public class StationPassengersRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	private const string RPC_NAME = RpcCall.STATION_PASSENGERS;

	private Station station;

	public StationPassengersRpcCallSenderProcessor(Station station)
		: base(RPC_NAME)
	{
		this.station = station;
	}

	public override void Send()
	{
		SendRpc(Builder().With(getStationName(), getStationPassengers()));
	}

	private string getStationName()
	{
		return station.name;
	}

	private string getStationPassengers()
	{
		return station.LocalPassengers.ToString();
	}
}
