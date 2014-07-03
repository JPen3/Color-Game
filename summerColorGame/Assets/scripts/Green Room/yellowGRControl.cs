using UnityEngine;
using System.Collections;

public class yellowGRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";

	private yellowGRExit yEObject;
	
	public bool initialLock = false;
	public bool isLocked = false;
	public bool isOpen = true;
	
	// Use this for initialization
	void Start () {	
		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorGRYellow");
		yEObject = doorYellow.GetComponent<yellowGRExit> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(yEObject.aniTexDone && isLocked)
		{
			Debug.Log("yellow Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName2).Play ();
			//oDObject.setOpen();
			isLocked = false;
			isOpen = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("You in the Blue Room Yellow Trigger");
		if(!initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("Yellow Door opens");
				//iTweenEvent.GetEvent (GameObject.Find ("hingeBRYellow"), eventName1).Play ();
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName2).Play ();
				//oDObject.setOpen();
				initialLock = true;
				isLocked = true;
				//isClosed = false;
			}
		}
		else if(yEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Yellow Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName2).Play ();
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
				//Debug.Log("Yellow Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeBRYellow"), eventName0).Play ();
				//oDObject.setOpen();
				//initialLock = true;
				isOpen = false;
			}
		}*/
		if (isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("Yellow Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName1).Play ();
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
