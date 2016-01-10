using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractNetworkEntity : NetworkEntity, NetworkEntityWaiting, NetworkEntityPlaying, RpcNetworkEntity
{
	protected NetworkView networkView;
	protected NetworkState networkState = NetworkState.Waiting;
	protected bool updated = true;

	protected NetworkTrainPlayers players = new NetworkTrainPlayers();

	protected RpcCallSender rpcCallSender = new RpcCallSender(networkView).DefaultToOthers();
	private RpcCallReceiver rpcCallReceiver;

	public AbstractNetworkEntity(NetworkView networkView)
	{
		this.networkView = networkView;
		this.rpcCallReceiver = new RpcCallReceiver(players, this);
	}

	public virtual void Start()
	{
		log("Network started");
		NetworkProxy.Initialize();
	}

	public virtual void End()
	{
		log("Network stopped");
	}

	public virtual void OnServerInitialized(NetworkPlayer player)
	{
		log ("Server initialized, reachable at: " + NetworkPlayerFormatter.getDebugName(player));
	}

	public void OnPlayerConnected(NetworkPlayer player)
	{
		log("Player connected: " + NetworkPlayerFormatter.getDebugName(player));
	}

	public virtual void OnPlayerDisconnected(NetworkPlayer player)
	{
		log("Player disconnected: " + NetworkPlayerFormatter.getDebugName(player));
	}

	public virtual void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		log("MasterServer event: " + masterServerEvent);
	}

	public virtual void OnConnectedToServer()
	{
		log("Connected to server");
	}

	public void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		log("Disconnected from server. Reason: " + info);
		players.RemoveAllPlayers();
	}

	public void OnRpc(string name, string data, NetworkPlayer player, NetworkMessageInfo info)
	{
		rpcCallReceiver.New(name, data, player, info).Process();
		updated = true;
	}

	protected virtual void Exchange()
	{
		rpcCallSender.AddPlayer();
	}

	public virtual void Play()
	{
		GameStorageKeys.NetworkTrains.Set(players);
		GameStorageKeys.NetworkEntityPlaying.Set(this);

		networkState = NetworkState.Loading;

		log("Disabling RPC processing while loading map");
		setRpcProcessing(false);
	}

	private void setRpcProcessing(bool status)
	{
		Network.isMessageQueueRunning = status;
	}

	public virtual void LocalMapLoaded()
	{
		log("Map loaded, enabling RPC processing again");
		setRpcProcessing(true);
		rpcCallSender.MapLoaded();
	}

	public void LocalRouteUpdated(Station nextStation)
	{
		rpcCallSender.RouteUpdate(nextStation);
	}

	public void LocalEndPoints(GamePoints points)
	{
		rpcCallSender.EndPoints(points);
	}

	public bool IsPlaying()
	{
		if (networkState != NetworkState.Playing) {
			if (players.AllReady()) {
				networkState = NetworkState.Playing;
			}
		}
		return networkState == NetworkState.Playing;
	}

	public bool Updated()
	{
		if (updated) {
			log("Network updated consumed");
			updated = false;
			return true;
		}
		return false;
	}

	protected void log(string text)
	{
		Log.Debug(text);
	}
}
