using UnityEngine;
using System.Collections;

public interface Movement
{
	bool Ended { get; }

	void Update(Vector3 to);
	void Step();
}
