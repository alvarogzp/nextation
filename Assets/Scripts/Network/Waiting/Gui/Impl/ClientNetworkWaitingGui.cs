public class ClientNetworkWaitingGui : AbstractNetworkWaitingGui
{
	private ClientNetworkEntityWaiting network;
	private GuiButtonRendererControl[] buttons = new GuiButtonRendererControl[0];

	public ClientNetworkWaitingGui(NetworkEntityWaiting networkEntity)
	{
		network = (ClientNetworkEntityWaiting) networkEntity;
	}

	protected override void Update()
	{
		if (network.Updated()) {
			Init();
			addServersHeader();
			addServers();
		}
		network.RefreshServers();
	}

	private void addServersHeader()
	{
		Add("Servers:", size: HEADING_SIZE, bold: true);
	}

	private void addServers()
	{
		string[] servers = network.GetServers();
		buttons = new GuiButtonRendererControl[servers.Length];
		for (int i = 0; i < servers.Length; i++) {
			buttons[i] = new GuiButtonRendererControl(() => network.Connect(i));
			addServer(servers[i], buttons[i]);
		}
	}

	private void addServer(string server, GuiRendererControl control)
	{
		Add(server, control: control);
	}

	protected override void HandleInput()
	{
		for (int i = 0; i < buttons.Length; i++) {
			buttons[i].Check();
		}
	}
}
