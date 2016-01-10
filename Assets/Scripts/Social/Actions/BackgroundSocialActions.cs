using UnityEngine;
using System.Collections;

public interface BackgroundSocialActions
{
	void ReportLoggedIn();
	void ReportMatchEnd(CurrentPoints points, bool isMultiplayer);
}
