public class RichTextFormatter
{
	private const string TAG_COLOR = "color";
	private const string TAG_BOLD = "b";
	private const string TAG_SIZE = "size";

	private string text;

	public static RichTextFormatter For(string text)
	{
		return new RichTextFormatter() { text = text };
	}

	public RichTextFormatter SetColor(string color)
	{
		surroundWithTag(TAG_COLOR, color);
		return this;
	}

	public RichTextFormatter SetBold()
	{
		surroundWithTag(TAG_BOLD);
		return this;
	}

	public RichTextFormatter SetSize(int size)
	{
		surroundWithTag(TAG_SIZE, size.ToString());
		return this;
	}

	public string Format()
	{
		return text;
	}

	private void surroundWithTag(string tagName, string tagValue = "")
	{
		if (tagValue.Length > 0) {
			tagValue = "=" + tagValue;
		}

		string openTag = "<" + tagName + tagValue + ">";
		string closeTag = "</" + tagName + ">";

		text = openTag + text + closeTag;
	}
}
