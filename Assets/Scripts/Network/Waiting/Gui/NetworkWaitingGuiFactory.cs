public class NetworkWaitingGuiFactory
{
	private NetworkEntityWaiting networkEntity;

	public static NetworkWaitingGuiFactory With(NetworkEntity networkEntity)
	{
		return new NetworkWaitingGuiFactory() { networkEntity = (NetworkEntityWaiting) networkEntity };
	}

	public NetworkWaitingGui Get(NetworkEntityRole role)
	{
		switch (role) {
		case NetworkEntityRole.Client:
			return new ClientNetworkWaitingGui(networkEntity);
		case NetworkEntityRole.Server:
			return new ServerNetworkWaitingGui(networkEntity);
		default:
			return null;
		}
	}
}
