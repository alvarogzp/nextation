using UnityEngine;
using System;
using System.Collections.Generic;

public class QueueActionRunnerGroup : QueueActionRunner
{
	private List<QueueActionRunner> runners;

	public QueueActionRunnerGroup(params QueueActionRunner[] runners)
	{
		this.runners = new List<QueueActionRunner>(runners);
	}

	public void Run(Action action)
	{
		runners.ForEach(r => r.Run(action));
	}

	public void RunAndClearQueue()
	{
		runners.ForEach(r => r.RunAndClearQueue());
	}
}
