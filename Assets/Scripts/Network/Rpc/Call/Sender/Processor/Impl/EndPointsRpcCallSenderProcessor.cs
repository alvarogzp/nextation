using UnityEngine;
using System.Collections;

public class EndPointsRpcCallSenderProcessor : AbstractRpcCallSenderProcessor
{
	private const string RPC_NAME = RpcCall.END_POINTS;

	private GamePoints points;

	public EndPointsRpcCallSenderProcessor(GamePoints points)
		: base(RPC_NAME)
	{
		this.points = points;
	}

	public override void Send()
	{
		SendRpc(Builder().With(getPoints()));
	}

	private string getPoints()
	{
		return points.Points.ToString();
	}
}
