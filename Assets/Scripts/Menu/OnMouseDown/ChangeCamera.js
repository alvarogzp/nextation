var newCamera : Camera;

function OnMouseDown ()
{
	disable(newCamera);
	enable(newCamera);
}

private function enable(camera : Camera)
{
	camera.enabled = true;
}

private function disable(camera : Camera)
{
	camera.enabled = false;
}
