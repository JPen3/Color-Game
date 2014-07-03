using UnityEngine;
using System.Collections;

public class magentaBRInk : MonoBehaviour {
	private itemPickup iPObject;
	private magentaBRExit mEObject;
	
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;
		
		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorBRMagenta");
		mEObject = doorMagenta.GetComponent<magentaBRExit> ();
		
		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorBRMagenta)
		{
			particleSystem.enableEmission = true;
			particleSystem.Play();
		}
		if(mEObject.aniTexDone)
		{
			particleSystem.enableEmission = false;
			particleSystem.Stop ();
		}
	}
}
