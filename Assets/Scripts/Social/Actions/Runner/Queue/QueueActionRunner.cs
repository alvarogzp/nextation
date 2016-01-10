using UnityEngine;
using System.Collections;

public interface QueueActionRunner : ActionRunner
{
	void RunAndClearQueue();
}
