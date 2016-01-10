using UnityEngine;
using System.Collections;

public class StationNameWithPassengersNumberTextFormatter : TextFormatter
{
	private Station station;
	private TextFormatter stationNameTextFormatter;

	public StationNameWithPassengersNumberTextFormatter(Station station)
	{
		this.station = station;
		stationNameTextFormatter = new StationNameTextFormatter(station);
	}

	public string GetId()
	{
		return stationNameTextFormatter.GetId();
	}

	public string GetFormattedText()
	{
		return formatPassengers(station.LocalPassengers) + "\n" + stationNameTextFormatter.GetFormattedText();
	}

	private string formatPassengers(int passengers)
	{
		//     "☺"
		return "\u263A" + passengers;
	}
}
