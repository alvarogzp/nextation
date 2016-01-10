public class Route
{
	private LinkedList<Station> route = new LinkedList<Station>();

	public Station Current {
		get {
			return route.First;
		}
	}

	public Station Last {
		get {
			return route.Last;
		}
	}

	public void Add(Station station)
	{
		route.Add(station);
	}

	public bool Advance()
	{
		if (route.Length > 1) {
			route.RemoveFirst();
			return true;
		}
		return false;
	}
}
