using UnityEngine;
using System.Collections;

public class cyanGRInk : MonoBehaviour {
	private itemPickup iPObject;
	private cyanGRExit cEObject;
	
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;
		
		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorGRCyan");
		cEObject = doorMagenta.GetComponent<cyanGRExit> ();
		
		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorGRCyan)
		{
			particleSystem.enableEmission = true;
			particleSystem.Play();
		}
		if(cEObject.aniTexDone)
		{
			particleSystem.enableEmission = false;
			particleSystem.Stop ();
		}
	}
}
