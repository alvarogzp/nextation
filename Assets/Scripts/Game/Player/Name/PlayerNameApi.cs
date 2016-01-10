using UnityEngine;
using System.Collections;

public class PlayerNameApi
{
	public const string LOCAL_PLAYER_NAME = "T\xfa";
	public const string NETWORK_PLAYER_START_NAME = "Jugador ";

	public static string GetLocalPlayerName()
	{
		return LOCAL_PLAYER_NAME;
	}

	public static string GetNetworkPlayerName(NetworkPlayer player)
	{
		return NETWORK_PLAYER_START_NAME + player.ToString();
	}
}
