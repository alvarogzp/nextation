using UnityEngine;
using System.Collections;

public class RpcCallFormatter
{
	private const string DATA_SEPARATOR = ", ";

	public static string getDebugName(RpcCallData rpc)
	{
		return rpc.Name + "@" + rpc.Sender + " (" + string.Join(DATA_SEPARATOR, rpc.Data) + ")";
	}
}
