using UnityEngine;
using System.Collections;

public abstract class AbstractTrainConfigurer : TrainConfigurer
{
	protected GameObject main;

	public AbstractTrainConfigurer(AbstractTrainRetriever retriever)
	{
		main = retriever.Main;
	}

	protected delegate void ConfigurationCall(Train train);

	protected abstract void configurate(ConfigurationCall call);

	public virtual void Configure()
	{
		configurate(gameObjectOperations);
		configurate(scaleTrain);
	}

	protected virtual void gameObjectOperations(Train train)
	{
		GameObjectOperations.To(main)
			.Hide()
			.SetRotation(train.gameObject);
		GameObjectOperations.To(train.gameObject)
			.SetParent(main)
			.SetPosition(main);
	}

	protected void scaleTrain(Train train)
	{
		train.transform.localScale *= GameMapSizeFactor.GetFactorForCurrentMapRelativeToMap(GameMap.MAP_02);
	}

	protected void enableTrainSound(Train train)
	{
		AudioSource audioSource = train.GetComponent<AudioSource>();
		if (audioSource) {
			audioSource.enabled = true;
		}
	}
}
