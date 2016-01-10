using UnityEngine;
using System.Collections;

public class GuiPlacementCalculatorApi
{
	public static GuiPlacement GetPlacement(GuiPositionWithReference position, Vector2 size)
	{
		return getPlacementCalculator(position.Position).For(position).With(size).GetPlacement();
	}

	private static GuiPlacementCalculator getPlacementCalculator(GuiPosition position)
	{
		switch (position) {
		case GuiPosition.CENTER:
			return new CenterGuiPlacementCalculator();
		case GuiPosition.CENTER_UP:
			return new CenterUpGuiPlacementCalculator();
		case GuiPosition.CENTER_DOWN:
			return new CenterDownGuiPlacementCalculator();
		case GuiPosition.CENTER_HALF_UP:
			return new CenterHalfUpGuiPlacementCalculator();
		case GuiPosition.CENTER_HALF_DOWN:
			return new CenterHalfDownGuiPlacementCalculator();
		case GuiPosition.UP_LEFT:
			return new UpLeftGuiPlacementCalculator();
		case GuiPosition.UP_CENTER:
			return new UpCenterGuiPlacementCalculator();
		case GuiPosition.UP_CENTER_HALF_LEFT:
			return new UpCenterHalftLeftGuiPlacementCalculator();
		case GuiPosition.UP_RIGHT:
			return new UpRightGuiPlacementCalculator();
		case GuiPosition.DOWN_LEFT:
			return new DownLeftGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER:
			return new DownCenterGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER_LEFT:
			return new DownCenterLeftGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER_RIGHT:
			return new DownCenterRightGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER_HALF_LEFT:
			return new DownCenterHalfLeftGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER_HALF_RIGHT:
			return new DownCenterHalfRightGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER_QUARTER_LEFT:
			return new DownCenterQuarterLeftGuiPlacementCalculator();
		case GuiPosition.DOWN_CENTER_QUARTER_RIGHT:
			return new DownCenterQuarterRightGuiPlacementCalculator();
		case GuiPosition.DOWN_RIGHT:
			return new DownRightGuiPlacementCalculator();
		case GuiPosition.ABOVE:
			return new AboveGuiPlacementCalculator();
		case GuiPosition.BELOW:
			return new BelowGuiPlacementCalculator();
		case GuiPosition.BEFORE:
			return new BeforeGuiPlacementCalculator();
		case GuiPosition.NEXT:
			return new NextGuiPlacementCalculator();
		default:
			return new DefaultGuiPlacementCalculator();
		}
	}
}
