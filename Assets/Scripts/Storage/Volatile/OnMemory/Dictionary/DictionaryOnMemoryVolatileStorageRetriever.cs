using UnityEngine;
using System.Collections;

public class DictionaryOnMemoryVolatileStorageRetriever
{
	public static DictionaryOnMemoryVolatileStorage<T> GetForKey<T>(GameStorageKey key)
	{
		return new DictionaryOnMemoryVolatileStorage<T>(key);
	}
}
