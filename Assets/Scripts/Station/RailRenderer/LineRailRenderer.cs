using UnityEngine;
using System.Collections;

public class LineRailRenderer : RailRenderer
{
	public void Render(Station from, Station to)
	{
		new LineRendererBuilder(railName(from, to))
			.SetMaterial(new Material(Shader.Find("Particles/Additive")))
			.SetColors(Color.green, Color.red)
			.SetWidth(0.2F, 0.2F)
			.SetPositions(from.transform.position, to.transform.position);
	}
	
	private string railName(Station from, Station to)
	{
		return "RailFrom" + from.name + "To" + to.name;
	}
}
