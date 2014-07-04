using UnityEngine;
using System.Collections;

public class cyanKey : MonoBehaviour {
	private itemPickup iPObject;
	private colorToggle cTObject;
	
	private bool blue = false;
	private bool green = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		
		GameObject lightObject = GameObject.FindGameObjectWithTag ("Flashlight");
		cTObject = lightObject.GetComponent<colorToggle> ();
		
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		blue = cTObject.getBlue();
		green = cTObject.getGreen();

		if (iPObject.cyanKey || (!blue || !green))
		{
			renderer.enabled = false;
		}
		else if (blue && green)
		{
			renderer.enabled = true;
		}
	}
}
