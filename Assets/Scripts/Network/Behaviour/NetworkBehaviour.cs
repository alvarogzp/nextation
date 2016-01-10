using UnityEngine;
using System.Collections;

public class NetworkBehaviour : MonoBehaviour
{
	public NetworkEntityRole NetworkRole;

	private NetworkEntity network;
	private NetworkWaitingGui gui;
	private string originalScene;
	private bool onWaitingScene = true;

	void Awake()
	{
		originalScene = Scene.GetCurrentSceneName();
	}

	void OnEnable ()
	{
		DontDestroyOnLoad(this.gameObject);
		initNetwork();
		initGui();
	}

	private void initNetwork()
	{
		NetworkView networkView = GetComponent<NetworkView>();
		network = NetworkEntityFactory.With(networkView).Get(NetworkRole);
		network.Start();
	}

	private void initGui()
	{
		gui = NetworkWaitingGuiFactory.With(network).Get(NetworkRole);
		gui.Init();
	}

	void OnGUI ()
	{
		if (onWaitingScene) {
			gui.Render();
		}
	}

	void OnServerInitialized(NetworkPlayer player)
	{
		network.OnServerInitialized(player);
	}

	void OnPlayerConnected(NetworkPlayer player)
	{
		network.OnPlayerConnected(player);
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		network.OnPlayerDisconnected(player);
	}

	void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		network.OnMasterServerEvent(masterServerEvent);
	}

	void OnConnectedToServer()
	{
		network.OnConnectedToServer();
	}

	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		network.OnDisconnectedFromServer(info);
	}

	void OnLevelWasLoaded(int levelIndex)
	{
		string currentScene = Scene.GetCurrentSceneName();
		onWaitingScene = currentScene == originalScene;
		bool onMainMenu = currentScene == SceneNames.MENU;
		if (onMainMenu || !(onWaitingScene || enabled)) {
			Destroy(this.gameObject);
		}
	}

	void OnDisable ()
	{
		network.End();
	}

	[RPC]
	public void RPC(string name, string data, NetworkPlayer player, NetworkMessageInfo info)
	{
		network.OnRpc(name, data, player, info);
	}
}
