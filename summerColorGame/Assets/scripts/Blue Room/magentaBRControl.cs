using UnityEngine;
using System.Collections;

public class magentaBRControl : MonoBehaviour {
	
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";

	private magentaBRExit mEObject;
	private roomsLoaded rLObject;

	private bool initialLock = false;
	private bool isLocked = true;
	private bool isOpen = false;
	private bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();
		
		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorBRMagenta");
		mEObject = doorMagenta.GetComponent<magentaBRExit> ();

		rLObject.setBlueLock (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rLObject.getBlueLock ())
		{
			initialLock = true;
			//isLocked = true;
			//isOpen = false;
		}

		isLoaded = rLObject.getRedRoom ();

		Debug.Log("Magenta Animation Blue Room " +mEObject.aniTexDone);
		Debug.Log("Magenta locked Blue Room " +isLocked);
		if(mEObject.aniTexDone && isLocked)
		{
			Debug.Log("Magenta Door opens Blue Room");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("redRum");
				rLObject.setRedRoom(true);
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeBRMagenta"), eventName1).Play ();
			//oDObject.setOpen();
			isLocked = false;
			isOpen = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("You in the Blue Room Magenta Trigger");
		if(!initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRMagenta"), eventName1).Play ();
				rLObject.setBlueLock(true);
				initialLock = true;
				isLocked = true;
				isOpen = true;
			}
		}
		else if(mEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Magenta Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeBRMagenta"), eventName1).Play ();
			isLocked = false;
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRMagenta"), eventName0).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRMagenta"), eventName2).Play ();
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