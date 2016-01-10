using UnityEngine;
using System.Collections;

public class MapNameRpcCallReceiverProcessor : AbstractRpcCallReceiverProcessor
{
	public override void Process()
	{
		setMap(receivedData.GetDataPart(0));
	}

	private void setMap(string map)
	{
		GameStorageKeys.SelectedMap.Set(map);
	}
}
