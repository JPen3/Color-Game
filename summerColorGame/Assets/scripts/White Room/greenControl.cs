using UnityEngine;
using System.Collections;

public class greenControl : MonoBehaviour {
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
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other)
	{
		isLoaded = rLObject.getGreenRoom ();
		if(!isOpen)
		{
			Debug.Log("Green Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("greenRoom");
				rLObject.setGreenRoom(true);
				isLoaded = rLObject.getGreenRoom ();
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeGreen"), eventName1).Play ();
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeGreen"), eventName2).Play ();
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
