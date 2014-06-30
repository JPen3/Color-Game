using UnityEngine;
using System.Collections;

public class openDoor1 : MonoBehaviour {
	private yellowExit yEObject;
	private closeDoor1 cDObject;
	
	private itemPickup iPObject;
	private bool isOpenMagenta;
	private bool isOpenYellow;
	private bool isOpenCyan;
	private bool isLoaded = false;

	public bool isOpen = false;
	
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();

		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorYellow");
		yEObject = doorYellow.GetComponent<yellowExit> ();
		
		GameObject triggerYellow = GameObject.FindGameObjectWithTag ("triggerYellow");
		cDObject = triggerYellow.GetComponent<closeDoor1> ();
	}
	
	// Update is called once per frame
	void Update () {
		isOpenMagenta = iPObject.doorMagenta;
		isOpenYellow = iPObject.doorYellow;
		isOpenCyan = iPObject.doorCyan;
		
		/*if(isOpenMagenta)
		{
			transform.Rotate(0,-90,0,Space.Self);
			Application.LoadLevelAdditiveAsync("blueDaDaDee");
			isOpenMagenta = !isOpenMagenta;
			iPObject.doorMagenta = isOpenMagenta;
		}*/
		if(yEObject.aniTexDone && !isLoaded)
		{
			iTweenEvent.GetEvent (GameObject.Find ("HingeRRyellow"), eventName1).Play ();
			Application.LoadLevelAdditiveAsync("greenRoom");
			//cDObject.setClosed();
			isOpen = true;
			isLoaded = true;
		}
	}
	public void setOpen()
	{
		isOpen = !isOpen;
	}
	
	public bool getLoaded()
	{
		return isLoaded;
	}
}
