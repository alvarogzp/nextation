using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager
{
	private NextStationSelector nextStationSelector;
	private NetworkEntityPlaying network;
	private Route route;
	private CameraManager cameraManager;
	private List<GuiButtonRendererControl> buttons = new List<GuiButtonRendererControl>();

	public InputManager(NextStationSelector nextStationSelector, NetworkEntityPlaying network)
	{
		this.nextStationSelector = nextStationSelector;
		this.network = network;
	}

	public void AddLocal(Route route, CameraManager cameraManager)
	{
		this.route = route;
		this.cameraManager = cameraManager;
	}

	public void AddButtons(params GuiButtonRendererControl[] buttons)
	{
		this.buttons.AddRange(buttons);
	}

	public void Handle()
	{
		HandleStationPress();
		HandleButtonsPress();
		HandleCamera();
	}

	private void HandleStationPress()
	{
		bool pressedScreen = Input.GetMouseButtonUp(0);
		if (pressedScreen) {
			Vector3 position = Input.mousePosition;
			Camera camera = cameraManager.Current;

			Station nextStation = nextStationSelector.GetNextStation(route.Last, position, camera);
			if (nextStation) {
				route.Add(nextStation);
				nextStation.StartHighlight();
				updateNetwork(nextStation);
			}
		}
	}

	private void updateNetwork(Station nextStation)
	{
		if (network != null) {
			network.LocalRouteUpdated(nextStation);
		}
	}

	private void HandleButtonsPress()
	{
		buttons.ForEach(b => b.Check());
	}

	private void HandleCamera()
	{
		cameraManager.Update();
	}
}
