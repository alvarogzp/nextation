using UnityEngine;

public class ServerNetworkWaitingGui : AbstractNetworkWaitingGui
{
	private const int MIN_PLAYERS_TO_SHOW_PLAY_BUTTON = 1;

	private ServerNetworkEntityWaiting network;
	private GuiButtonRendererControl playButton;

	public ServerNetworkWaitingGui(NetworkEntityWaiting networkEntity)
	{
		network = (ServerNetworkEntityWaiting) networkEntity;
		playButton = new GuiButtonRendererControl(() => network.Play());

		defaultColor = "navy";
	}

	protected override void Update()
	{
		if (network.Updated()) {
			Init();
			addRegisterStatus();
			addPlayers();
			addPlayButton();
		}
	}

	private void addRegisterStatus()
	{
		string text;

		MasterServerEvent registerStatus = network.GetRegisterStatus();
		switch (registerStatus) {
		case MasterServerEvent.RegistrationSucceeded:
			text = "Partida creada, esperando jugadores...";
			break;
		case MasterServerEvent.HostListReceived:
			text = "Creando partida...";
			break;
		default:
			text = "Error al crear partida: " + registerStatus;
			break;
		}

		Add(text, size: HEADING_SIZE, bold: true);
	}

	private void addPlayers()
	{
		foreach (string player in network.GetPlayers()) {
			Add(player);
		}
	}

	private void addPlayButton()
	{
		int opponents = network.GetPlayersCount();
		if (opponents >= MIN_PLAYERS_TO_SHOW_PLAY_BUTTON) {
			string playText = "¡Jugar!\n" + opponents + " oponente" + (opponents != 1 ? "s" : "");
			Add(playText, BUTTON_SIZE, true, "lime", playButton);
		}
	}

	protected override void HandleInput()
	{
		playButton.Check();
	}
}
