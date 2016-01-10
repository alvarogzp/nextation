using UnityEngine;
using System.Collections;

public class Pixels
{
	private const int DEFAULT_DPI = 96;

	private static float screenDpiFactor = Screen.dpi / DEFAULT_DPI;

	public static float ScreenDpiFactor {
		get {
			return screenDpiFactor;
		}
	}

	public static int GetDensityIndependentPixels(int pixels)
	{
		return (int) (pixels * screenDpiFactor);
	}
}
