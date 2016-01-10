using UnityEngine;
using System.Collections;

public class StationPassengersRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		Station station = get<Station>(receivedData.GetDataPart(0));
		int passengers = int.Parse(receivedData.GetDataPart(1));
		stationPassengers(station, passengers);
	}

	private void stationPassengers(Station station, int passengers)
	{
		station.SetInitialPassengers(passengers);
	}
}
