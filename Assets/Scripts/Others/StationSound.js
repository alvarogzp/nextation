function OnTriggerEnter(other : Collider)
{
	if (other.tag == "wagon") {
		GetComponent.<AudioSource>().Play();
	}
}
