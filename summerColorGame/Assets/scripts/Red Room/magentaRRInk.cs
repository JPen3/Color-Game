using UnityEngine;
using System.Collections;

public class magentaRRInk : MonoBehaviour {
	private itemPickup iPObject;
	private magentaRRExit mEObject;


	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;

		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorRRMagenta");
		mEObject = doorMagenta.GetComponent<magentaRRExit> ();

		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorRRMagenta)
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
