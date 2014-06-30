using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	//private itemPickup iPObject;
	private magentaExit mEObject;
	private closeDoor cDObject;

	private bool isOpenMagenta;
	private bool isOpenYellow;
	private bool isOpenCyan;
	private bool isLoaded = false;

	public bool isOpen = false;
	public bool initialLock = true;

	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	// Use this for initialization
	void Start () {
		//GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		//iPObject = playerObject.GetComponent<itemPickup> ();

		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorMagenta");
		mEObject = doorMagenta.GetComponent<magentaExit> ();

		GameObject triggerMagenta = GameObject.FindGameObjectWithTag ("triggerMagenta");
		cDObject = triggerMagenta.GetComponent<closeDoor> ();
	}
	
	// Update is called once per frame
	void Update () {
		//isOpenMagenta = iPObject.doorMagenta;
		//isOpenYellow = iPObject.doorYellow;
		//isOpenCyan = iPObject.doorCyan;

		if(mEObject.aniTexDone && !isLoaded && initialLock)
		{
			Debug.Log("Magenta Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("HingeRRmagenta"), eventName1).Play ();
			Application.LoadLevelAdditiveAsync("blueDaDaDee");
			//isOpenMagenta = !isOpenMagenta;
			//iPObject.doorMagenta = isOpenMagenta;
			cDObject.setClosed();
			initialLock = false;
			isOpen = true;
			isLoaded = true;
		}
		//Debug.Log("Door Open is " + isOpen);
		/*if(isOpenMagenta && !isLoaded)
		{
			Application.LoadLevelAdditiveAsync("blueDaDaDee");
			transform.Rotate(0,-90,0,Space.Self);
			isOpenMagenta = !isOpenMagenta;
			iPObject.doorMagenta = isOpenMagenta;
			isLoaded = true;
		}*/
		/*if(isOpenYellow)
		{
			transform.Rotate(0,-90,0,Space.Self);
			Application.LoadLevelAdditiveAsync("greenRoom");
			isOpenYellow = !isOpenYellow;
			iPObject.doorYellow = isOpenYellow;
		}*/
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
