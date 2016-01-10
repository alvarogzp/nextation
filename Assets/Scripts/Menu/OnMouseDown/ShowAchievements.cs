using UnityEngine;
using System.Collections;

public class ShowAchievements : MonoBehaviour
{
	void OnMouseDown ()
	{
		SocialManager.ForegroundActions.ShowAchievements();
	}
}
