var Speed : int = 10;
var Direction : Vector3 = -Vector3.forward;

function Update ()
{
	transform.Translate(Direction * Speed * Time.deltaTime);
}
