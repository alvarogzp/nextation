using UnityEngine;
using System.Collections;

public class LineRendererBuilder
{
	private LineRenderer line;
	
	public LineRendererBuilder(string name)
	{
		line = new GameObject(name).AddComponent<LineRenderer>();
	}
	
	public LineRendererBuilder SetMaterial(Material material)
	{
		line.material = material;
		return this;
	}

	public LineRendererBuilder SetColors(Color start, Color end)
	{
		line.SetColors(start, end);
		return this;
	}
	
	public LineRendererBuilder SetWidth(float start, float end)
	{
		line.SetWidth(start, end);
		return this;
	}
	
	public LineRendererBuilder SetPositions(Vector3 from, Vector3 to)
	{
		line.SetVertexCount(2);
		line.SetPosition(0, from);
		line.SetPosition(1, to);
		return this;
	}
}
