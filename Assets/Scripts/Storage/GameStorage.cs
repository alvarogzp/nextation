using UnityEngine;
using System.Collections;

public interface GameStorage<T>
{
	void Set(T value);

	/**
	 * Gets the value of the previously stored record with the key.
	 *
	 * @throws KeyNotFoundException if key does not contains anything
	 * @see Has() to check if the key exists
	 */
	T Get();

	bool Exists();

	void Delete();
}
