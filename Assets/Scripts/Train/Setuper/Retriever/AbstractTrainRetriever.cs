using UnityEngine;
using System.Collections;

public abstract class AbstractTrainRetriever : TrainRetriever
{
	protected GameObject main;

	public GameObject Main {
		get {
			return main;
		}
	}

	public AbstractTrainRetriever(GameObject main)
	{
		this.main = main;
	}

	protected abstract bool exists();
	protected abstract void retrieve();
	protected abstract void useDefaultTrain();

	public void Retrieve()
	{
		if (exists()) {
			retrieve();
		} else {
			useDefaultTrain();
		}
	}

	protected Train retrieve(string trainName)
	{
		GameObject trainGameObject = GameObjectFinder.WithName(trainName);
		return trainGameObject.GetComponent<Train>();
	}
}
