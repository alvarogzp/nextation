using UnityEngine;
using System.Collections;

public class Station : MonoBehaviour
{
	// Public variables
	public string DisplayName;
	public Station[] NextStations;

	private int localPassengers;
	private StationPassengers passengers = new PerTrainStationPassengers();
	private WorldTextRenderer stationNameWorldTextRenderer;
	private StationHighlighter highlighter;

	public StationPassengers Passengers {
		get {
			return passengers;
		}
	}
	public int LocalPassengers {
		get {
			return localPassengers;
		}
		set {
			updateLocalPassengers(value);
		}
	}

	void Awake()
	{
		highlighter = new StationHighlighter(transform.position);
		SetInitialPassengers(RandomNumberStationPassengersGenerator.GetRandomPassengers());
		GameObject nameObject = StationNameObjectFinder.GetStationNameObject(this);
		if (nameObject) {
			stationNameWorldTextRenderer = new GameWorldTextRenderer(new StationNameWithPassengersNumberTextFormatter(this), nameObject.transform.position);
			updateStationName(stationNameWorldTextRenderer);
		}
		//drawRails(new LineRailRenderer());
	}

	void OnDrawGizmos()
	{
		GameObject nameObject = StationNameObjectFinder.GetStationNameObject(this);
		if (nameObject) {
			WorldTextRenderer gizmosStationNameWorldTextRenderer = new HandlesWorldTextRenderer(new StationNameTextFormatter(this), nameObject.transform.position);
			updateStationName(gizmosStationNameWorldTextRenderer);
		}
		drawRails(new GizmosRailRenderer());
	}

	public void SetInitialPassengers(int initialPassengers)
	{
		passengers.SetInitial(initialPassengers);
		updateLocalPassengers(initialPassengers);
	}

	private void updateLocalPassengers(int newLocalPassengers)
	{
		localPassengers = newLocalPassengers;
		updateStationName(stationNameWorldTextRenderer);
	}

	public void StartHighlight()
	{
		highlighter.StartHighlight();
	}

	public void EndHighlight()
	{
		highlighter.EndHighlight();
	}

	private void updateStationName(WorldTextRenderer renderer)
	{
		if (renderer != null) {
			renderer.Render();
		}
	}

	private void drawRails(RailRenderer renderer)
	{
		foreach (Station station in NextStations) {
			renderer.Render(this, station);
		}
	}
}
