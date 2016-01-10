using UnityEngine;
using System.Collections;

public class PlayerFactory
{
	public static Player CreateLocal(Train train)
	{
		string name = PlayerNameApi.GetLocalPlayerName();
		return new Player(name, train, true);
	}
}
