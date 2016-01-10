public class MovementManager
{
	private Station firstStation;
	private Station lastStation;
	private Route route;
	private Movement movement;
	private Movement normalMovement;
	private Movement goOutMovement;
	private TrainPassengers passengers;
	private TimeCounter timeCounter;
	private CurrentPoints points;
	private GuiManager gui;
	private GuiRendererControl backToMenuButton;
	private GuiRendererControl showRankingButton;
	private bool isLocal;
	private GuiPlayersPointsElement playersPoints;
	private NetworkEntityPlaying network;

	private bool reachedLastStation = false;

	public MovementManager(Station firstStation, Station lastStation, Route route, Movement firstMovement, Movement normalMovement, Movement goOutMovement, TrainPassengers passengers, TimeCounter timeCounter, CurrentPoints points, GuiManager gui, GuiRendererControl backToMenuButton, GuiRendererControl showRankingButton, bool isLocal, GuiPlayersPointsElement playersPoints, NetworkEntityPlaying network)
	{
		this.firstStation = firstStation;
		this.lastStation = lastStation;
		this.route = route;
		this.movement = firstMovement;
		this.normalMovement = normalMovement;
		this.goOutMovement = goOutMovement;
		this.passengers = passengers;
		this.timeCounter = timeCounter;
		this.points = points;
		this.gui = gui;
		this.backToMenuButton = backToMenuButton;
		this.showRankingButton = showRankingButton;
		this.isLocal = isLocal;
		this.playersPoints = playersPoints;
		this.network = network;
	}

	public void Handle()
	{
		if (!movement.Ended) {
			HandleMove();
		}

		if (movement.Ended) {
			HandleAdvance();
		}
	}

	private void HandleMove()
	{
		movement.Step();

		if (movement.Ended) {
			HandleArrive(route.Current);
		}
	}

	private void HandleAdvance()
	{
		bool advanced = route.Advance();
		if (advanced) {
			movement.Update(route.Current.transform.position);
		}
	}

	private void HandleArrive(Station station)
	{
		if (!reachedLastStation) {
			passengers.arrivedAt(station);
			if (isLocal) {
				station.EndHighlight();
			}
		}

		if (station == firstStation) {
			HandleFirst();
		}

		if (station == lastStation) {
			HandleEnd();
		}
	}

	private void HandleFirst()
	{
		movement = normalMovement;
	}

	private void HandleEnd()
	{
		movement = goOutMovement;
		reachedLastStation = true;
		goToHiddenStationIfExists();

		timeCounter.End();

		if (isLocal) {
			handleLocalEnd();
		}
	}

	private void goToHiddenStationIfExists()
	{
		if (lastStation.NextStations.Length > 0) {
			route.Add(lastStation.NextStations[0]);
		}
	}

	private void handleLocalEnd()
	{
		GamePoints finalPoints = points.GetPoints();

		if (network != null) {
			network.LocalEndPoints(finalPoints);
		}

		SocialManager.BackgroundActions.ReportMatchEnd(points, playersPoints.PlayersCount > 1);

		PointsHistory pointsHistory = PointsHistoryFactory.GetForCurrentMap();
		pointsHistory.AddPoints(finalPoints);
		GamePoints maxPoints = pointsHistory.GetMaxPoints();

		gui.AddElement(GuiElementFactory.GetEndElement(maxPoints, backToMenuButton, showRankingButton));
		playersPoints.DisplayEndView();
	}
}
