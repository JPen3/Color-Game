using UnityEngine;
using System.Collections;

public class cyanBRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";

	private cyanBRExit cEObject;
	private roomsLoaded rLObject;
	
	private bool initialLock = false;
	private bool isLocked = true;
	private bool isOpen = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();

		GameObject doorCyan = GameObject.FindGameObjectWithTag ("doorBRCyan");
		cEObject = doorCyan.GetComponent<cyanBRExit> ();

		rLObject.setBlueLock (false);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Cyan Door " +isOpen);

		if (rLObject.getBlueLock ())
		{
			initialLock = true;
			//isLocked = true;
			//isOpen = false;
		}

		if(cEObject.aniTexDone && isLocked)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeBRCyan"), eventName2).Play ();
			//oDObject.setOpen();
			isLocked = false;
			isOpen = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("You in the Blue Room Cyan Trigger");
		if(!initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("Magenta Door opens");
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRCyan"), eventName2).Play ();
				//oDObject.setOpen();
				rLObject.setBlueLock(true);
				initialLock = true;
				isLocked = true;
				isOpen = true;
			}
		}
		else if(cEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeBRCyan"), eventName2).Play ();
			//oDObject.setOpen();
			isOpen = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		/*if(initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				Debug.Log("I'm Batman!");
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRmagenta"), eventName0).Play ();
				//oDObject.setOpen();
				//initialLock = false;
				isLocked = true;
				isOpen = false;
			}
		}*/
		if (isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("Magenta Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRCyan"), eventName1).Play ();
				//oDObject.setOpen();
				//initialLock = true;
				isOpen = false;
			}
		}
	}
	public void setClosed()
	{
		isOpen = !isOpen;
	}
	
	public bool getClosed()
	{
		return isOpen;
	}
}
