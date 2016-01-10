using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{
	public Font SymbolsFont;

	void OnGUI ()
	{
		GUI.skin.font = SymbolsFont;
		enabled = false;
	}

	void Start()
	{
		SocialManager.Init();
	}
}
