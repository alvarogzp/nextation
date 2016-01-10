using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	// Constants
	private const bool TERRESTRIAL = true;

	// Public variables
	public Station FirstStation;
	public Station LastStation;
	public NextStationSelector NextStationSelector = new MatchingNextStationSelector();
	public StepType RotationDefaultStepType = new SmoothStepType();
	public StepType TranslationStartStepType = new LinearWithSlowEndStepType();
	public StepType TranslationDefaultStepType = new SmoothStepType();
	public static TrainPassengersLimitType TrainPassengersLimitType = TrainPassengersLimitType.PerStation;

	// Private variables
	private GuiManager gui;
	private InputManager input;
	private List<MovementManager> movements;

	private bool playing = false;
	private NetworkEntityPlaying network;
	private List<TimeCounter> timeCounters;

	void Start ()
	{
		gui = new GuiManager();
		movements = new List<MovementManager>();
		timeCounters = new List<TimeCounter>();

		GameStorage<NetworkEntityPlaying> networkEntityPlayingStorage = GameStorageKeys.NetworkEntityPlaying;
		if (networkEntityPlayingStorage.Exists()) {
			network = networkEntityPlayingStorage.Get();
			networkEntityPlayingStorage.Delete();
			network.LocalMapLoaded();
		}

		input = new InputManager(NextStationSelector, network);

		GuiPlayersPointsElement playersPoints = new GuiPlayersPointsElement();
		gui.AddElement(playersPoints);

		LocalTrainSetuper localTrainSetuper = TrainSetuperFactory.On(this.gameObject).Local();
		localTrainSetuper.Setup();
		Train train = localTrainSetuper.Get();
		movements.Add(getMovementFor(train, isLocalTrain: true, networkPlayer: null, playersPoints: playersPoints, network: network));

		NetworkTrainSetuper networkTrainSetuper = TrainSetuperFactory.On(this.gameObject).Network();
		networkTrainSetuper.Setup();
		NetworkTrainPlayer[] networkPlayers = networkTrainSetuper.Get();
		foreach (NetworkTrainPlayer networkPlayer in networkPlayers) {
			movements.Add(getMovementFor(networkPlayer.Train, isLocalTrain: false, networkPlayer: networkPlayer, playersPoints: playersPoints, network: network));
		}
	}

	private MovementManager getMovementFor(Train train, bool isLocalTrain, NetworkTrainPlayer networkPlayer, GuiPlayersPointsElement playersPoints, NetworkEntityPlaying network)
	{
		float rotationSpeed = train.RotationSpeed;
		float translationSpeed = train.TranslationSpeed * GameMapSizeFactor.GetFactorForCurrentMapRelativeToFirstMap();
		int maxPassengers = train.MaxPassengers;
		Transform mover = train.transform.parent ?? train.transform;

		TransformOperations.To(mover).SetRotationTo(FirstStation.transform.position);

		Route route = new Route();
		route.Add(null);
		route.Add(FirstStation);

		if (isLocalTrain) {
			FirstStation.StartHighlight();
		}

		Player player = networkPlayer == null ? PlayerFactory.CreateLocal(train) : networkPlayer;

		TrainPassengersLimit trainPassengersLimit = TrainPassengersLimitFactory.Get(TrainPassengersLimitType);
		trainPassengersLimit.SetLimit(maxPassengers);
		TrainPassengers passengers = new TrainPassengers(trainPassengersLimit, player);

		TimeCounter timeCounter = new TimeCounter();
		timeCounters.Add(timeCounter);

		CurrentPoints points = new CurrentPoints(CurrentMap.GetCurrentMap(), passengers, timeCounter);
		playersPoints.AddPoints(player, points);

		GuiButtonRendererControl backToMenuButton = null;
		GuiButtonRendererControl showRankingButton = null;

		Movement firstMovement, normalMovement, goOutMovement;
		if (isLocalTrain) {
			Camera camera = Camera.main;
			Vector3 cameraOffset = -(mover.position - camera.transform.position);

			firstMovement = new ParallelMovement()
				.AddMovement(new TranslationMovement(mover, translationSpeed, TranslationStartStepType, TERRESTRIAL))
				.AddMovement(new TranslationMovement(camera.transform, translationSpeed, TranslationStartStepType, TERRESTRIAL, cameraOffset));
			//firstMovement.Update(FirstStation.transform.position);

			normalMovement = new SequentialMovement()
				.AddMovement(new RotationMovement(mover, rotationSpeed, RotationDefaultStepType, TERRESTRIAL))
				.AddMovement(new ParallelMovement()
					.AddMovement(new TranslationMovement(mover, translationSpeed, TranslationDefaultStepType, TERRESTRIAL))
					.AddMovement(new TranslationMovement(camera.transform, translationSpeed, TranslationDefaultStepType, TERRESTRIAL, cameraOffset)));

			goOutMovement = new SequentialMovement()
				.AddMovement(new RotationMovement(mover, rotationSpeed, RotationDefaultStepType, TERRESTRIAL))
				.AddMovement(new TranslationMovement(mover, translationSpeed, TranslationDefaultStepType, TERRESTRIAL));

			MapCamera trainCamera = new TrainCamera(Camera.main);
			MapCamera freeCamera = new FreeCamera(Camera.main);
			CameraManager cameraManager = new CameraManager(trainCamera);

			backToMenuButton = new GuiButtonRendererControl(() => Application.LoadLevel(SceneNames.MENU));
			showRankingButton = new GuiButtonRendererControl(() => SocialManager.ForegroundActions.ShowLeaderboard(CurrentMap.GetCurrentMap()));
			GuiButtonRendererControl setTrainCameraButton = new GuiButtonRendererControl(() => cameraManager.SetCamera(trainCamera));
			GuiButtonRendererControl setFreeCameraButton = new GuiButtonRendererControl(() => cameraManager.SetCamera(freeCamera));

			gui.AddElement(new GuiHudElement(passengers, timeCounter));
			gui.AddElement(GuiElementFactory.GetSwitchCameraElement("Train\nCam", GuiPosition.DOWN_LEFT, setTrainCameraButton));
			gui.AddElement(GuiElementFactory.GetSwitchCameraElement("Free\nCam", GuiPosition.DOWN_RIGHT, setFreeCameraButton));

			input.AddLocal(route, cameraManager);
			input.AddButtons(backToMenuButton, showRankingButton, setTrainCameraButton, setFreeCameraButton);
		} else {
			firstMovement = new TranslationMovement(mover, translationSpeed, TranslationStartStepType, TERRESTRIAL);
			//firstMovement.Update(FirstStation.transform.position);

			goOutMovement = normalMovement = new SequentialMovement()
				.AddMovement(new RotationMovement(mover, rotationSpeed, RotationDefaultStepType, TERRESTRIAL))
				.AddMovement(new TranslationMovement(mover, translationSpeed, TranslationDefaultStepType, TERRESTRIAL));

			networkPlayer.SetRoute(route);
		}

		return new MovementManager(FirstStation, LastStation, route, firstMovement, normalMovement, goOutMovement, passengers, timeCounter, points, gui, backToMenuButton, showRankingButton, isLocalTrain, playersPoints, network);
	}

	void Update ()
	{
		if (isPlaying()) {
			input.Handle();
			movements.ForEach(m => m.Handle());
		}
	}

	private bool isPlaying()
	{
		if (playing) {
			return true;
		} else {
			return getPlayingStatus();
		}
	}

	private bool getPlayingStatus()
	{
		if (network != null) {
			playing = network.IsPlaying();
		} else {
			playing = true;
		}

		if (playing) {
			timeCounters.ForEach(t => t.Start());
		}
		return playing;
	}

	void OnGUI()
	{
		gui.Render();
	}
}
