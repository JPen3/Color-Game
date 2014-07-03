using UnityEngine;
using System.Collections;

public class cyanGRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";

	private cyanGRExit cEObject;
	
	public bool initialLock = true;
	public bool isLocked = true;
	public bool isOpen = false;
	
	// Use this for initialization
	void Start () {
		
		GameObject doorCyan = GameObject.FindGameObjectWithTag ("doorBRCyan");
		cEObject = doorCyan.GetComponent<cyanGRExit> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(cEObject.aniTexDone && isLocked)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeBRcyan"), eventName2).Play ();
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
				//iTweenEvent.GetEvent (GameObject.Find ("hingeBRmagenta"), eventName1).Play ();
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRcyan"), eventName2).Play ();
				//oDObject.setOpen();
				initialLock = true;
				//isClosed = false;
			}
		}
		else if(cEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRcyan"), eventName2).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRcyan"), eventName1).Play ();
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
