using UnityEngine;
using System;
using System.Collections;

public class SocialActionReportToEvents
{
	private CurrentPoints points;
	private bool isMultiplayer;

	public SocialActionReportToEvents(CurrentPoints points, bool isMultiplayer)
	{
		this.points = points;
		this.isMultiplayer = isMultiplayer;
	}

	public void Report()
	{
		reportEvent(SocialEvents.PASSENGERS, points.Passengers);
		reportEvent(SocialEvents.TIME, points.Time);
		reportEvent(SocialEvents.MATCHES, 1);
		reportEvent(isMultiplayer ? SocialEvents.MULTIPLAYER_MATCHES : SocialEvents.INDIVIDUAL_MATCHES, 1);
		reportEvent(SocialEvents.GetEventForMap(points.Map), 1);
	}

	public static void ReportLoggedIn()
	{
		reportEvent(SocialEvents.LOGGED_IN, 1);
	}

	private static void reportEvent(string eventId, int increment)
	{
		if (eventId != SocialEvents.NO_EVENT) {
			SocialPlayGames.Get.Events.IncrementEvent(eventId, Convert.ToUInt32(increment));
			Log.Debug("Social: Event reported (event: " + eventId + ", increment: " + increment + ")");
		} else {
			Log.Debug("Social: No event to report");
		}
	}
}
