using UnityEngine;
using System.Collections;

public class redControl : MonoBehaviour {
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private roomsLoaded rLObject;
	
	public bool initialLock = true;
	public bool isLocked = true;
	public bool isOpen = false;
	public bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		rLObject = playerObject.GetComponent<roomsLoaded> ();

		//rLObject.setRedLock (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other)
	{
		isLoaded = rLObject.getRedRoom ();
		if(!isOpen)
		{
			Debug.Log("Red Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("redRum");
				rLObject.setRedRoom(true);
				isLoaded = rLObject.getRedRoom ();
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeRed"), eventName1).Play ();
			rLObject.setRedLock(true);
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeRed"), eventName2).Play ();
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
