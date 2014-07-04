using UnityEngine;
using System.Collections;

public class magentaKey : MonoBehaviour {

	private itemPickup iPObject;
	private colorToggle cTObject;
	
	private bool red = false;
	private bool green = false;
	private bool blue = false;
	
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
		red = cTObject.getRed();
		green = cTObject.getGreen();
		blue = cTObject.getBlue ();

		if (iPObject.magentaKey|| (!red || !blue || green))
		{
			renderer.enabled = false;
		}
		else if (red && !green && blue)
		{
			renderer.enabled = true;
		}
	}
}
