using UnityEngine;
using System.Collections;

public class ShowRankings : MonoBehaviour
{
	void OnMouseDown ()
	{
		SocialManager.ForegroundActions.ShowLeaderboards();
	}
}
