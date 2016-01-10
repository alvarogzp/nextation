public class PlayersPointsSorter
{
	public static int ByPoints(GuiPlayerPoints x, GuiPlayerPoints y)
	{
		return y.Data.Points - x.Data.Points;
	}
}
