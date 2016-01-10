using UnityEngine;
using System.Collections;

public abstract class BaseOnMouseDownMenu : MonoBehaviour
{
	protected void store<T>(GameStorage<T> storage, T data)
	{
		storage.Set(data);
	}

	protected void advanceMenuFrom(MenuState currentState)
	{
		MenuFlowState.From(currentState).Advance();
	}
}
