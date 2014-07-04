using UnityEngine;
using System.Collections;

public class magentaRRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private magentaRRExit mEObject;
	private roomsLoaded rLObject;
	
	private bool initialLock = false;
	private bool isLocked = true;
	private bool isOpen = false;
	private bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();

		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorRRMagenta");
		mEObject = doorMagenta.GetComponent<magentaRRExit> ();

		//rLObject.setRedLock (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rLObject.getRedLock ())
		{
			initialLock = true;
		}

		isLoaded = rLObject.getBlueRoom ();

		if(mEObject.aniTexDone && isLocked)
		{
			Debug.Log("Red Room's Magenta Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("blueDaDaDee");
				rLObject.setBlueRoom(true);
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRMagenta"), eventName1).Play ();
			isLocked = false;
			isOpen = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("You in the Blue Room Cyan Trigger");
		if(!initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				iTweenEvent.GetEvent (GameObject.Find ("hingeRRMagenta"), eventName1).Play ();
				rLObject.setRedLock(true);
				initialLock = true;
				isLocked = true;
				isOpen = true;
			}
		}
		else if(mEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRMagenta"), eventName1).Play ();
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
				//Debug.Log("Magenta Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeRRMagenta"), eventName2).Play ();
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
