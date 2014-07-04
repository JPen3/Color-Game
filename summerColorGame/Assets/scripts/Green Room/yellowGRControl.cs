using UnityEngine;
using System.Collections;

public class yellowGRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private yellowGRExit yEObject;
	private roomsLoaded rLObject;
	
	private bool initialLock = false;
	private bool isLocked = true;
	private bool isOpen = false;
	private bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();
		
		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorGRYellow");
		yEObject = doorYellow.GetComponent<yellowGRExit> ();
		
		rLObject.setGreenLock (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rLObject.getGreenLock ())
		{
			initialLock = true;
		}
		
		isLoaded = rLObject.getRedRoom ();
		
		if(yEObject.aniTexDone && isLocked)
		{
			Debug.Log("Yellow Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("redRum");
				rLObject.setRedRoom(true);
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName2).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName2).Play ();
				rLObject.setGreenLock(true);
				initialLock = true;
				isLocked = true;
				isOpen = true;
			}
		}
		else if(yEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName2).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeGRYellow"), eventName1).Play ();
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
