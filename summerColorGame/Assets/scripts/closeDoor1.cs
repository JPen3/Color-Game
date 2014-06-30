using UnityEngine;
using System.Collections;

public class closeDoor1 : MonoBehaviour {
	
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private openDoor1 oDObject;
	private yellowExit yEObject;
	
	public bool isClosed = true;
	
	// Use this for initialization
	void Start () {
		GameObject hingeYellow = GameObject.FindGameObjectWithTag ("hingeYellow");
		oDObject = hingeYellow.GetComponent<openDoor1> ();
		
		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorYellow");
		yEObject = doorYellow.GetComponent<yellowExit> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(yEObject.aniTexDone && !oDObject.isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				Debug.Log("Yellow Door opens");
				iTweenEvent.GetEvent (GameObject.Find ("HingeRRyellow"), eventName1).Play ();
				oDObject.setOpen();
				isClosed = false;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(oDObject.isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				Debug.Log("Yellow Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("HingeRRyellow"), eventName2).Play ();
				oDObject.setOpen();
				isClosed = true;
			}
		}
	}
	public void setClosed()
	{
		isClosed = !isClosed;
	}
	
	public bool getClosed()
	{
		return isClosed;
	}
}
