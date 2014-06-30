using UnityEngine;
using System.Collections;

public class blueKey : MonoBehaviour {
	private itemPickup iPObject;
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (iPObject.blueKey)
		{
			renderer.enabled = false;
		}
		else
		{
			renderer.enabled = true;
		}
	}
}
