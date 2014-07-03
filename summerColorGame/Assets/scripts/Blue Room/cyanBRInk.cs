using UnityEngine;
using System.Collections;

public class cyanBRInk : MonoBehaviour {
	private itemPickup iPObject;
	private cyanBRExit cEObject;
	
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;
		
		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorBRCyan");
		cEObject = doorMagenta.GetComponent<cyanBRExit> ();
		
		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorBRCyan)
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
