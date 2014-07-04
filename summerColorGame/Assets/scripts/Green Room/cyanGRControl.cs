using UnityEngine;
using System.Collections;

public class cyanGRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";

	private cyanGRExit cEObject;
	private roomsLoaded rLObject;
	
	private bool initialLock = false;
	private bool isLocked = true;
	private bool isOpen = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();
		
		GameObject doorCyan = GameObject.FindGameObjectWithTag ("doorGRCyan");
		cEObject = doorCyan.GetComponent<cyanGRExit> ();

		rLObject.setGreenLock (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rLObject.getGreenLock ())
		{
			initialLock = true;
		}

		if(cEObject.aniTexDone && isLocked)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRCyan"), eventName2).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRCyan"), eventName2).Play ();
				rLObject.setGreenLock(true);
				initialLock = true;
				isLocked = true;
				isOpen = true;
			}
		}
		else if(cEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRCyan"), eventName2).Play ();
			isLocked = false;
			isOpen = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRCyan"), eventName1).Play ();
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
