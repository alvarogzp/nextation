public class StationNameTextFormatter : TextFormatter
{
	private const string COMMON_START = "Station";
	private const string SPACE = " ";
	private static char[] UPPERCASE_LETTERS = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '\xC1', '\xC9', '\xCD', '\xD3', '\xDA' };

	private Station station;

	public StationNameTextFormatter(Station station)
	{
		this.station = station;
	}

	public string GetId()
	{
		return station.name;
	}

	public string GetFormattedText()
	{
		return isEmpty(station.DisplayName) ? formatStationName(station.name) : station.DisplayName;
	}

	private bool isEmpty(string s)
	{
		return s == null || s == "";
	}

	private string formatStationName(string name)
	{
		name = removeFromStart(name, COMMON_START);
		name = addStringBeforeMatchingLetters(name, 1, UPPERCASE_LETTERS, SPACE);

		return name;
	}

	private string removeFromStart(string s, string toRemove)
	{
		if (s.StartsWith(toRemove)) {
			s = s.Substring(toRemove.Length);
		}

		return s;
	}

	private string addStringBeforeMatchingLetters(string s, int start, char[] letters, string toAdd)
	{
		int index = start;
		while ((index = s.IndexOfAny(letters, index)) != -1) {
			s = s.Insert(index, toAdd);
			index += toAdd.Length + 1;
		}

		return s;
	}
}
