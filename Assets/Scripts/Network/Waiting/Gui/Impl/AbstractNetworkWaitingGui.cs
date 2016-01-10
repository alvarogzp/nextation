using UnityEngine;

public abstract class AbstractNetworkWaitingGui : NetworkWaitingGui
{
	protected const int HEADING_SIZE = 15;
	protected const int NORMAL_TEXT_SIZE = 12;
	protected const int BUTTON_SIZE = 12;

	protected GuiManager manager;
	protected GuiContentRenderer lastGuiElement;

	protected GuiPosition firstPosition = GuiPosition.UP_CENTER;
	protected GuiPosition defaultPosition = GuiPosition.BELOW;
	protected string defaultColor = string.Empty;
	protected int defaultSize = NORMAL_TEXT_SIZE;
	protected bool defaultBold = false;
	protected GuiRendererControl defaultControl = null;

	protected abstract void Update();
	protected abstract void HandleInput();

	public void Init()
	{
		manager = new GuiManager();
		lastGuiElement = null;
	}

	public void Render()
	{
		Update();
		manager.Render();
		HandleInput();
	}

	protected void Add(string text)
	{
		Add(text, defaultSize, defaultBold);
	}

	protected void Add(string text, GuiRendererControl control)
	{
		Add(text, defaultSize, control);
	}

	protected void Add(string text, int size, GuiRendererControl control)
	{
		Add(text, size, defaultBold, defaultColor, control);
	}

	protected void Add(string text, int size, bool bold)
	{
		Add(text, size, bold, defaultColor, defaultControl);
	}

	protected void Add(string text, int size, bool bold, string color, GuiRendererControl control)
	{
		RichTextFormatter textFormatter = RichTextFormatter.For(text);
		if (color.Length > 0) {
			textFormatter.SetColor(color);
		}
		if (bold) {
			textFormatter.SetBold();
		}
		textFormatter.SetSize(Pixels.GetDensityIndependentPixels(size));
		text = textFormatter.Format();

		GuiPosition position = lastGuiElement == null ? firstPosition : defaultPosition;
		GuiTextRendererBuilder textRendererBuilder = new GuiTextRendererBuilder().WithRichText(text).InPosition(position, lastGuiElement);
		if (control != null) {
			textRendererBuilder.WithControl(control);
		}

		lastGuiElement = textRendererBuilder.Get();
		manager.AddElement(new GuiStaticElement(lastGuiElement));
	}
}
