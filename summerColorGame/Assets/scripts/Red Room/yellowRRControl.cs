using UnityEngine;
using System.Collections;

public class yellowRRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private yellowRRExit yEObject;
	private roomsLoaded rLObject;
	
	private bool initialLock = false;
	private bool isLocked = true;
	private bool isOpen = false;
	private bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();

		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorRRYellow");
		yEObject = doorYellow.GetComponent<yellowRRExit> ();

		//rLObject.setRedLock (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rLObject.getRedLock ())
		{
			initialLock = true;
		}

		isLoaded = rLObject.getGreenRoom ();

		if(yEObject.aniTexDone && isLocked)
		{
			Debug.Log("Yellow Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("greenRoom");
				rLObject.setGreenRoom(true);
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName1).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName1).Play ();
				rLObject.setRedLock(true);
				initialLock = true;
				isLocked = true;
				isOpen = true;
			}
		}
		else if(yEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName1).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName2).Play ();
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
