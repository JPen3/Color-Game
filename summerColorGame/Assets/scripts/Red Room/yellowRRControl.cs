using UnityEngine;
using System.Collections;

public class yellowRRControl : MonoBehaviour {
	string eventName0 = "lockdoor";
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private yellowRRExit yEObject;
	
	public bool initialLock = true;
	public bool isLocked = true;
	public bool isOpen = false;
	public bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		GameObject doorCyan = GameObject.FindGameObjectWithTag ("doorRRYellow");
		yEObject = doorCyan.GetComponent<yellowRRExit> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(yEObject.aniTexDone && isLocked)
		{
			Debug.Log("Yellow Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("greenRoom");
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName1).Play ();
			isLocked = false;
			isOpen = true;
			isLoaded = true;
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
				iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName2).Play ();
				initialLock = true;
			}
		}
		else if(yEObject.aniTexDone && !isOpen)
		{
			Debug.Log("Cyan Door opens");
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRYellow"), eventName1).Play ();
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
