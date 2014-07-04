using UnityEngine;
using System.Collections;

public class colorToggle : MonoBehaviour {

	Color c = new Color (0, 0, 0);

	private bool redOn = false;
	private bool greenOn = false;
	private bool blueOn = false;

	private itemPickup iPObject;

	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Red " + redOn);
		Debug.Log ("Green " + greenOn);
		Debug.Log ("Blue " + blueOn);

		if(iPObject.redLens)
		{
			if (Input.GetButtonDown ("toggleRed") && redOn == false) {
				redOn = true;
				c.r = 1;
				//light.color = c;
			}
			else if (Input.GetButtonDown ("toggleRed") && redOn == true) {
				redOn = false;
				c.r = 0;
				//light.color = c;
			}
		}
		if(iPObject.greenLens)
		{
			if (Input.GetButtonDown ("toggleGreen") && greenOn == false) {
				greenOn = true;
				c.g = 1;
				//light.color = c;
			}
			else if (Input.GetButtonDown ("toggleGreen") && greenOn == true) {
				greenOn = false;
				c.g = 0;
				//light.color = c;
			}
		}
		if(iPObject.blueLens)
		{
			if (Input.GetButtonDown ("toggleBlue") && blueOn == false) {
				blueOn = true;
				c.b = 1;
				//light.color = c;
			}
			else if (Input.GetButtonDown ("toggleBlue") && blueOn == true) {
				blueOn = false;
				c.b = 0;
				//light.color = c;
			}
		}
		light.color = c;

	}
	public bool getRed()
	{
		return redOn;
	}
	public bool getGreen()
	{
		return greenOn;
	}
	public bool getBlue()
	{
		return blueOn;
	}
}
