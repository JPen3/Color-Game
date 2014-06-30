using UnityEngine;
using System.Collections;

public class magentaInk : MonoBehaviour {
	private itemPickup iPObject;
	private magentaExit mEObject;


	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;

		GameObject doorMagenta = GameObject.FindGameObjectWithTag ("doorMagenta");
		mEObject = doorMagenta.GetComponent<magentaExit> ();

		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorMagenta)
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
