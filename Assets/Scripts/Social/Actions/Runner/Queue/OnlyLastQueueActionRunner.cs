using UnityEngine;
using System;

public class OnlyLastQueueActionRunner : QueueActionRunner
{
	private Action lastAction;

	public void Run(Action action)
	{
		lastAction = action;
	}

	public void RunAndClearQueue()
	{
		if (lastAction != null) {
			lastAction();
			lastAction = null;
		}
	}
}
