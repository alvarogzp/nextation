using UnityEngine;
using System.Collections;

public class NetworkPlayerFormatter
{
	public static string getDisplayName(NetworkPlayer player)
	{
		return formatAddress(player.ipAddress, player.port);
	}

	public static string getDebugName(NetworkPlayer player)
	{
		string address = formatAddress(player.ipAddress, player.port);
		string externalAddress = "(Ext:" + formatAddress(player.externalIP, player.externalPort) + ")";
		string guid = "[" + player.guid + "]";
		return string.Join(" ", new string[] {address, externalAddress, guid, player.ToString()});
	}

	private static string formatAddress(string ip, int port)
	{
		return ip + ":" + port;
	}
}
