using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class NetworkTrainPlayers
{
	private List<NetworkTrainPlayer> players = new List<NetworkTrainPlayer>();

	public int Count {
		get {
			return players.Count;
		}
	}
	public string[] TrainNames {
		get {
			return Select(p => p.TrainName);
		}
	}

	public void AddPlayer(NetworkTrainPlayer player)
	{
		players.Add(player);
	}

	public void RemovePlayer(NetworkTrainPlayer player)
	{
		player.DestroyTrain();
		players.Remove(player);
	}

	public void RemoveAllPlayers()
	{
		players.ForEach(p => p.DestroyTrain());
		players.Clear();
	}

	public NetworkTrainPlayer GetPlayer(NetworkPlayer player)
	{
		return players.Find(p => p.Has(player));
	}

	public NetworkTrainPlayer GetPlayer(Train train)
	{
		return players.Find(p => p.Has(train));
	}

	public bool AllReady()
	{
		return players.TrueForAll(p => p.IsReady());
	}

	public T[] Select<T>(Func<NetworkTrainPlayer, T> selector)
	{
		return players.Select(selector).ToArray();
	}

	public NetworkTrainPlayer[] asArray()
	{
		return players.ToArray();
	}
}
