using UnityEngine;
using System.Collections;

public class yellowGRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private openDoor oDObject;
	private yellowExit1 yEObject;
	
	public bool initialLock = false;
	public bool isLocked = true;
	public bool isOpen = true;
	
	// Use this for initialization
	void Start () {
		GameObject hingeYellow = GameObject.FindGameObjectWithTag ("hingeGRYellow");
		oDObject = hingeYellow.GetComponent<openDoor> ();
		
		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorGRYellow");
		yEObject = doorYellow.GetComponent<yellowExit1> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(yEObject.aniTexDone && isLocked)
		{
			Debug.Log("yellow Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRyellow"), eventName2).Play ();
			//oDObject.setOpen();
			isLocked = false;
			isOpen = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("You in the Blue Room yellow Trigger");
		if(!initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("yellow Door opens");
				//iTweenEvent.GetEvent (GameObject.Find ("hingeBRyellow"), eventName1).Play ();
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRyellow"), eventName2).Play ();
				//oDObject.setOpen();
				initialLock = true;
				//isClosed = false;
			}
		}
		else if(yEObject.aniTexDone && !isOpen)
		{
			Debug.Log("yellow Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRyellow"), eventName2).Play ();
			//oDObject.setOpen();
			isOpen = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		/*
		if(initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("yellow Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRyellow"), eventName0).Play ();
				//oDObject.setOpen();
				//initialLock = true;
				isOpen = false;
			}
		}*/
		if (isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("yellow Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRyellow"), eventName1).Play ();
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
