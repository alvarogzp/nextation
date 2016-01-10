using UnityEngine;
using System.Collections;

public class RpcCallDataFormatter
{
	private const char RPC_CALL_DATA_SEPARATOR = '\n';

	public static string Join(string[] data)
	{
		return string.Join(RPC_CALL_DATA_SEPARATOR.ToString(), data);
	}

	public static string[] Split(string data)
	{
		return data.Split(RPC_CALL_DATA_SEPARATOR);
	}
}
