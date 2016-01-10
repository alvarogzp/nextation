using UnityEngine;
using System;

public class ImmediateActionRunner : ActionRunner
{
	public void Run(Action action)
	{
		action();
	}
}
