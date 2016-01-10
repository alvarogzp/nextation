using UnityEngine;
using System.Collections;

public class NetworkTrainPlayer : Player
{
	private NetworkPlayer networkPlayer;
	private Route route;
	private NetworkState state = NetworkState.Waiting;
	private GamePoints endPoints;

	public NetworkTrainPlayer(Train train, NetworkPlayer networkPlayer)
		: base(PlayerNameApi.GetNetworkPlayerName(networkPlayer), train, false)
	{
		this.networkPlayer = networkPlayer;
		Log.Debug("Added train: " + TrainName);
	}

	public void MapLoaded()
	{
		state = NetworkState.Ready;
	}

	public bool IsReady()
	{
		return state == NetworkState.Ready;
	}

	public bool Has(NetworkPlayer player)
	{
		return networkPlayer == player;
	}

	public bool Has(Train train)
	{
		return train.name == TrainName;
	}

	public void DestroyTrain()
	{
		Log.Debug("Removing train: " + TrainName);
		Train.Destroy();
	}

	public void SetRoute(Route route)
	{
		this.route = route;
	}

	public void AddToRoute(Station station)
	{
		route.Add(station);
	}

	public void SetEndPoints(GamePoints points)
	{
		endPoints = points;
	}

	public GamePoints GetEndPoints()
	{
		return endPoints;
	}
}
