using UnityEngine;
using System.Collections;

public class yellowRRInk : MonoBehaviour {
	private itemPickup iPObject;
	private yellowRRExit yEObject;
	
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;
		
		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorRRYellow");
		yEObject = doorYellow.GetComponent<yellowRRExit> ();
		
		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorRRYellow)
		{
			particleSystem.enableEmission = true;
			particleSystem.Play();
		}
		if(yEObject.aniTexDone)
		{
			particleSystem.enableEmission = false;
			particleSystem.Stop ();
		}
	}
}
