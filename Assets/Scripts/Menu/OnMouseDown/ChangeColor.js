var color : Color = Color.white;
var shader : String = "Transparent/Diffuse";
var receiveShadows : boolean = false;

function OnMouseDown () 
{
	var renderer = getRenderer();
	setColor(renderer, color);
	setShader(renderer, shader);
	setReceiveShadows(renderer, receiveShadows);
}

private function getRenderer()
{
	return GetComponent.<Renderer>();
}

private function setColor(renderer : Renderer, color)
{
	renderer.material.color = color;
}

private function setShader(renderer : Renderer, shader)
{
	renderer.material.shader = Shader.Find(shader);
}

private function setReceiveShadows(renderer : Renderer, receiveShadows)
{
	renderer.receiveShadows = receiveShadows;
}
