using UnityEngine;
using System.Collections;

public class yellowKey : MonoBehaviour {
		private itemPickup iPObject;
		private colorToggle cTObject;

		private bool red = false;
		private bool green = false;

		// Use this for initialization
		void Start () {
			GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
			iPObject = playerObject.GetComponent<itemPickup> ();

			GameObject lightObject = GameObject.FindGameObjectWithTag ("Flashlight");
			cTObject = lightObject.GetComponent<colorToggle> ();

			renderer.enabled = false;
		}
		
		// Update is called once per frame
		void Update () {
			red = cTObject.getRed();
			green = cTObject.getGreen();

			if (iPObject.yellowKey || (!red || !green))
			{
				renderer.enabled = false;
			}
			else if (red && green)
			{
				renderer.enabled = true;
			}
		}
	}

