using UnityEngine;
using System.Collections;

public class LocalTrainRetriever : AbstractTrainRetriever
{
	private Train train;
	private GameStorage<string> selectedTrainStorage = GameStorageKeys.SelectedTrain;

	public Train Train {
		get {
			return train;
		}
	}

	public LocalTrainRetriever(GameObject main)
		: base(main)
	{}

	protected override bool exists()
	{
		return selectedTrainStorage.Exists();
	}

	protected override void retrieve()
	{
		string trainName = selectedTrainStorage.Get();
		selectedTrainStorage.Delete();

		train = retrieve(trainName);
	}

	protected override void useDefaultTrain()
	{
		createTestTrain();
	}

	private void createTestTrain()
	{
		train = main.AddComponent<Train>();
	}
}
