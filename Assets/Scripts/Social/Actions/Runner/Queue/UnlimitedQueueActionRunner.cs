using UnityEngine;
using System;
using System.Collections.Generic;

public class UnlimitedQueueActionRunner : QueueActionRunner
{
	private List<Action> actions = new List<Action>();

	public void Run(Action action)
	{
		actions.Add(action);
	}

	public void RunAndClearQueue()
	{
		actions.ForEach(a => a());
		actions.Clear();
	}
}
