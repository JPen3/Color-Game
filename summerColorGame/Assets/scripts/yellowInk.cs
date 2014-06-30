using UnityEngine;
using System.Collections;

public class yellowInk : MonoBehaviour {

		private itemPickup iPObject;
		private yellowExit yEObject;
		
		
		// Use this for initialization
		void Start () {
			GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
			iPObject = playerObject.GetComponent<itemPickup> ();
			particleSystem.enableEmission = false;
			
			GameObject doorYellow = GameObject.FindGameObjectWithTag ("doorYellow");
			yEObject = doorYellow.GetComponent<yellowExit> ();
			
			//ParticleSystem inkFallSystem = (ParticleSystem)gameObject.GetComponent ("inkFallSystem");
			//inkFallSystem.enableEmission = false;
		}
		
		// Update is called once per frame
		void Update () {
			if(iPObject.doorYellow)
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
