using UnityEngine;
using System.Collections;

public class blueControl : MonoBehaviour {
	string eventName1 = "opendoor";
	string eventName2 = "closedoor";
	
	private magentaRRExit mEObject;
	
	public bool initialLock = true;
	public bool isLocked = true;
	public bool isOpen = false;
	public bool isLoaded = false;
	
	// Use this for initialization
	void Start () {
		//GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorRRMagenta");
		//mEObject = doorMagenta.GetComponent<magentaRRExit> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if(mEObject.aniTexDone && isLocked)
		{
			Debug.Log("Red Room's Magenta Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("blueDaDaDee");
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeRRMagenta"), eventName1).Play ();
			isLocked = false;
			isOpen = true;
			isLoaded = true;
		}*/
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("You in the Blue Room Cyan Trigger");
		/*if(!initialLock)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("Magenta Door opens");
				iTweenEvent.GetEvent (GameObject.Find ("hingeRRMagenta"), eventName2).Play ();
				initialLock = true;
			}
		}*/
		if(!isOpen)
		{
			Debug.Log("Red Door opens");
			if(!isLoaded)
			{
				Application.LoadLevelAdditiveAsync("blueDaDaDee");
			}
			iTweenEvent.GetEvent (GameObject.Find ("hingeBlue"), eventName1).Play ();
			isOpen = true;
			isLoaded = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		
		if (isOpen)
		{
			if(other.collider.gameObject.CompareTag ("Player"))
			{
				//Debug.Log("Magenta Door closes");
				iTweenEvent.GetEvent (GameObject.Find ("hingeBlue"), eventName2).Play ();
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
