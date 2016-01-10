using UnityEngine;
using System.Collections;

public class ClientNetworkEntity : AbstractNetworkEntity, ClientNetworkEntityWaiting
{
	private const float HOST_LIST_REQUEST_MINIMUM_INTERVAL = 3;

	private HostData[] hosts = new HostData[0];
	private float nextAllowedHostListRequest = 0;

	public ClientNetworkEntity(NetworkView networkView)
		: base(networkView)
	{}

	public override void Start()
	{
		base.Start();
		MasterServer.ClearHostList();
		requestHostList();
	}

	public void RefreshServers()
	{
		if (Time.time >= nextAllowedHostListRequest) {
			requestHostList();
		}
	}

	private void requestHostList()
	{
		log("Host list requested");
		MasterServer.RequestHostList(NetworkConstants.MASTER_SERVER_GAME_TYPE_NAME);
		nextAllowedHostListRequest = Time.time + HOST_LIST_REQUEST_MINIMUM_INTERVAL;
	}

	public string[] GetServers()
	{
		string[] servers = new string[hosts.Length];
		for (int i = 0; i < hosts.Length; i++) {
			HostData host = hosts[i];
			servers[i] = HostDataFormatter.getDisplayName(host);
			log(HostDataFormatter.getDebugName(host));
		}
		return servers;
	}

	public void Connect(int index)
	{
		HostData host = hosts[index];
		int port = NetworkGameFormatter.ParseCommentPort(host.comment);

		log("Connecting to: " + HostDataFormatter.getDebugName(host));
		NetworkProxy.Connect(port);
	}

	public override void OnConnectedToServer()
	{
		base.OnConnectedToServer();
		if (networkState == NetworkState.Waiting) {
			Exchange();
		}
	}

	public override void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		base.OnMasterServerEvent(masterServerEvent);
		if (masterServerEvent == MasterServerEvent.HostListReceived) {
			hostListReceived();
		}
	}

	private void hostListReceived()
	{
		log("Host list received");
		hosts = MasterServer.PollHostList();
		MasterServer.ClearHostList();
		updated = true;
	}

	public override void Play()
	{
		base.Play();
		MenuFlowState.From(MenuState.ClientWaiting).Advance();
	}

	public void Disconnect()
	{
		Network.Disconnect();
	}

	public override void End()
	{
		base.End();
		Disconnect();
		MasterServer.ClearHostList();
	}
}
