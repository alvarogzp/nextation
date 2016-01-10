using UnityEngine;
using System.Collections;

public class NetworkEntityFactory
{
	private NetworkView networkView;

	public static NetworkEntityFactory With(NetworkView networkView)
	{
		return new NetworkEntityFactory() { networkView = networkView };
	}

	public NetworkEntity Get(NetworkEntityRole role)
	{
		switch (role) {
		case NetworkEntityRole.Client:
			return new ClientNetworkEntity(networkView);
		case NetworkEntityRole.Server:
			return new ServerNetworkEntity(networkView);
		default:
			return null;
		}
	}
}
