using UnityEngine;
using System.Collections;

public class HostDataFormatter
{
	public static string getDisplayName(HostData host)
	{
		return host.comment;
	}

	public static string getDebugName(HostData host)
	{
		string hostName = host.gameType + " " + host.gameName + " " + host.comment + " [" + host.guid + "]";
		string players = "(" + host.connectedPlayers + "/" + host.playerLimit + ")";
		string addresses = "{" + string.Join(":", host.ip) + ":" + host.port + "}";
		string nat = "N:" + host.useNat;
		string password = "P:" + host.passwordProtected;
		return string.Join(" ", new string[] {hostName, players, addresses, nat, password});
	}
}
