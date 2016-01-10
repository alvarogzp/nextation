using UnityEngine;
using System.Collections;

public class RemoteTrainName
{
	public static string GetNameFor(Train train, NetworkPlayer player)
	{
		return train.name + "@" + player.ToString();
	}
}
