using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ServerNetworkEntity : AbstractNetworkEntity, ServerNetworkEntityWaiting
{
	private const int MAX_NUMBER_OF_OTHER_PLAYERS = 9;
	private const int PORT = 4789;
	private const bool USE_NAT_FACILITATOR = false;

	private MasterServerEvent registerStatus = MasterServerEvent.HostListReceived;

	public ServerNetworkEntity(NetworkView networkView)
		: base(networkView)
	{}

	public override void Start()
	{
		base.Start();
		NetworkProxy.Start();
		setIncomingPassword();
		Network.InitializeServer(MAX_NUMBER_OF_OTHER_PLAYERS, PORT, USE_NAT_FACILITATOR);
		Exchange();
	}

	private void setIncomingPassword()
	{
		Network.incomingPassword = "This password is set to a very complex string to avoid direct conections to server, they must be done through proxy";
	}

	public MasterServerEvent GetRegisterStatus()
	{
		return registerStatus;
	}

	public string[] GetPlayers()
	{
		return players.Select(p => p.PlayerName);
	}

	public int GetPlayersCount()
	{
		return players.Count;
	}

	public override void OnServerInitialized(NetworkPlayer player)
	{
		base.OnServerInitialized(player);
		MasterServer.RegisterHost(NetworkConstants.MASTER_SERVER_GAME_TYPE_NAME, NetworkGameFormatter.GetGameName(), NetworkGameFormatter.GetGameComment(player));
	}

	public override void OnPlayerDisconnected(NetworkPlayer player)
	{
		base.OnPlayerDisconnected(player);

		// This event only reach server, so we need to tell clients via an RPC
		rpcCallSender.RemovePlayer(player);

		// Suggested by Unity example:
		//Network.RemoveRPCs(player); // No, because as the REMOVE_TRAIN is not him, won't be removed
		//Network.DestroyPlayerObjects(player); // No object created remotely in this game (by now)
	}

	public override void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		base.OnMasterServerEvent(masterServerEvent);
		registerStatus = masterServerEvent;
		updated = true;
	}

	protected override void Exchange()
	{
		rpcCallSender.MapName();
		base.Exchange();
	}

	public override void Play()
	{
		if (networkState == NetworkState.Waiting) {
			//MasterServer.UnregisterHost(); // TODO Does not unregisters, but prevents updates, appearing as a server with free slots
			rpcCallSender.Play();
			base.Play();
			MenuFlowState.From(MenuState.ServerWaiting).Advance();
		}
	}

	public override void LocalMapLoaded()
	{
		base.LocalMapLoaded();
		sendStationPassengers();
	}

	private void sendStationPassengers()
	{
		Station[] stations = GameObjectFinder.All<Station>();
		foreach (Station station in stations) {
			rpcCallSender.StationPassengers(station);
		}
	}

	public override void End()
	{
		base.End();
		Network.Disconnect();
		MasterServer.UnregisterHost();
		NetworkProxy.End();
	}
}
