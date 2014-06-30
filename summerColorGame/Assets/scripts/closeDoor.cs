using UnityEngine;
using System.Collections;

public class closeDoor : MonoBehaviour {

	string eventName1 = "opendoor";
	string eventName2 = "closedoor";

	private openDoor oDObject;
	private magentaExit mEObject;

	public bool isClosed = true;

	// Use this for initialization
	void Start () {
		GameObject hingeMagenta = GameObject.FindGameObjectWithTag ("hingeMagenta");
		oDObject = hingeMagenta.GetComponent<openDoor> ();

		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorMagenta");
		mEObject = doorMagenta.GetComponent<magentaExit> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(mEObject.aniTexDone && !oDObject.isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				Debug.Log("Magenta Door opens");
				iTweenEvent.GetEvent (GameObject.Find ("HingeRRmagenta"), eventName1).Play ();
				oDObject.setOpen();
				isClosed = false;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(oDObject.isOpen && !oDObject.initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				Debug.Log("Magenta Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("HingeRRmagenta"), eventName2).Play ();
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
