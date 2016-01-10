public interface ClientNetworkEntityWaiting : NetworkEntityWaiting
{
	void RefreshServers();
	string[] GetServers();

	void Connect(int serverIndex);
}
