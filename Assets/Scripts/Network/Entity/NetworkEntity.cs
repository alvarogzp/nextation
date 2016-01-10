using UnityEngine;

public interface NetworkEntity
{
	void Start();
	void End();

	void OnServerInitialized(NetworkPlayer player);
	void OnPlayerConnected(NetworkPlayer player);
	void OnPlayerDisconnected(NetworkPlayer player);
	void OnMasterServerEvent(MasterServerEvent masterServerEvent);
	void OnConnectedToServer();
	void OnDisconnectedFromServer(NetworkDisconnection info);

	void OnRpc(string name, string data, NetworkPlayer player, NetworkMessageInfo info);
}
