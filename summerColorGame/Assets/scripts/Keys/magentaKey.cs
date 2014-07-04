using UnityEngine;
using System.Collections;

public class magentaKey : MonoBehaviour {

	private itemPickup iPObject;
	private colorToggle cTObject;
	
	private bool red = false;
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
		blue = cTObject.getBlue();

		if (iPObject.magentaKey|| (!red || !blue))
		{
			renderer.enabled = false;
		}
		else if (red && blue)
		{
			renderer.enabled = true;
		}
	}
}
