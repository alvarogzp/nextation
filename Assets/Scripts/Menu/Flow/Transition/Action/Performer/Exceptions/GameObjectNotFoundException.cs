using System;

public class GameObjectNotFoundException : Exception
{
	public GameObjectNotFoundException(string name)
		: base(String.Format("Game object not found: {0}", name))
	{
	}
}
