using UnityEngine;
using System.Collections;

public class yellowGRInk : MonoBehaviour {
	private itemPickup iPObject;
	private yellowGRExit yEObject;
	
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		particleSystem.enableEmission = false;
		
		GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorGRYellow");
		yEObject = doorYellow.GetComponent<yellowGRExit> ();
		
		//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
		//inkFallSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorGRYellow)
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
