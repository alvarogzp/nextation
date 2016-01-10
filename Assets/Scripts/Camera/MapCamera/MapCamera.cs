using UnityEngine;
using System.Collections;

public interface MapCamera
{
	Camera Camera { get; }

	void Activate();
	void Update();
	void Deactivate();
}
