using UnityEngine;
using System.Collections;

public class RpcCallData
{
	private string name;
	private string[] data;
	private NetworkPlayer sender;

	public string Name {
		get {
			return name;
		}
	}
	public string[] Data {
		get {
			return data;
		}
	}
	public string DataString {
		get {
			return GetDataAsString();
		}
	}
	public NetworkPlayer Sender {
		get {
			return sender;
		}
	}

	public RpcCallData(string name, string[] data, NetworkPlayer sender)
	{
		this.name = name;
		this.data = data;
		this.sender = sender;
	}

	public string GetDataPart(int index)
	{
		return data[index];
	}

	public string GetDataAsString()
	{
		return RpcCallDataFormatter.Join(data);
	}

	public static string[] GetDataParts(string data)
	{
		return RpcCallDataFormatter.Split(data);
	}
}
