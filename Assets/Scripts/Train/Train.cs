using UnityEngine;
using System.Collections;
using System;

public class Train : MonoBehaviour
{
	public int MaxPassengers = 100;
	public float RotationSpeed = 120;
	public float TranslationSpeed = 70;

	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void OnLevelWasLoaded(int levelIndex)
	{
		if (!shouldKeepTrain()) {
			Destroy();
		}
	}

	private bool shouldKeepTrain()
	{
		return isKeepTrainScene() ||
			(isKeepSelectedTrainScene() && (isCurrentTrainSelected() || isNetworkTrain()));
	}

	private bool isKeepTrainScene()
	{
		return Scene.GetCurrentSceneName() == SceneNames.TRAIN_SELECTION ||
			Scene.GetCurrentSceneName() == SceneNames.MAP_SELECTION;
	}

	private bool isKeepSelectedTrainScene()
	{
		return CurrentMap.isMap();
	}

	private bool isCurrentTrainSelected()
	{
		return selectedTrainName() == trainName();
	}

	private bool isNetworkTrain()
	{
		foreach (string networkTrain in networkTrainsNames()) {
			if (networkTrain == trainName()) {
				return true;
			}
		}
		return false;
	}

	private string selectedTrainName()
	{
		GameStorage<string> selectedTrainStorage = GameStorageKeys.SelectedTrain;
		return selectedTrainStorage.Exists() ? selectedTrainStorage.Get() : "";
	}

	private string[] networkTrainsNames()
	{
		GameStorage<NetworkTrainPlayers> networkTrainsStorage = GameStorageKeys.NetworkTrains;
		return networkTrainsStorage.Exists() ? networkTrainsStorage.Get().TrainNames : new string[0];
	}

	private string trainName()
	{
		return this.name;
	}

	public void Destroy()
	{
		Destroy(this.gameObject);
	}
}
