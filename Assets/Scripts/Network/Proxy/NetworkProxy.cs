using UnityEngine;
using System.Collections;

public class NetworkProxy
{
	private const string PROXY_ADDRESS = "proxy.unity3d.com"; //"nextation-proxy.no-ip.org"; //"192.168.1.6";
	private const int PROXY_PORT = 10746;
	private const string PROXY_PASSWORD = "";

	public static void Initialize()
	{
		Network.proxyIP = PROXY_ADDRESS;
		Network.proxyPort = PROXY_PORT;
		Network.proxyPassword = PROXY_PASSWORD;
	}

	public static void Start()
	{
		Network.useProxy = true;
	}

	public static void Connect(int port)
	{
		Network.Connect(PROXY_ADDRESS, port, PROXY_PASSWORD);
	}

	public static void End()
	{
		Network.useProxy = false;
	}
}
