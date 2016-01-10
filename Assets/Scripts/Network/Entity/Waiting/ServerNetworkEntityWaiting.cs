using UnityEngine;

public interface ServerNetworkEntityWaiting : NetworkEntityWaiting
{
	MasterServerEvent GetRegisterStatus();
	string[] GetPlayers();
	int GetPlayersCount();

	void Play();
}
