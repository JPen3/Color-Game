using UnityEngine;
using System.Collections;

public class itemPickup : MonoBehaviour {
	public bool redLens = false;
	public bool greenLens = false;
	public bool blueLens = false;

	public bool magentaKey = false;
	public bool yellowKey = false;
	public bool cyanKey = false;

	public bool doorRRMagenta = false;
	public bool doorRRYellow = false;

	public bool doorBRMagenta = false;
	public bool doorBRCyan = false;
	
	public bool doorGRYellow = false;
	public bool doorGRCyan = false;

	private int redKeyCount = 0;
	private int greenKeyCount = 0;
	private int blueKeyCount = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.mainCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		Debug.DrawRay (ray.origin, ray.direction * 10, Color.cyan);
		RaycastHit hit;

		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast (ray, out hit) == true)
			{
				Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.red);
				Debug.Log("Ray hit a " + hit.transform.gameObject.tag);
				switch(hit.transform.gameObject.tag)
				{
					case "redLens":
						redLens = true;
						Destroy(hit.transform.gameObject);
						break;
					case "greenLens":
						greenLens = true;
						Destroy(hit.transform.gameObject);
						break;
					case "blueLens":
						blueLens = true;
						Destroy(hit.transform.gameObject);
						break;
					case "magentaKey":
						magentaKey = true;
						yellowKey = false;
						cyanKey = false;
						break;
					case "yellowKey":
						magentaKey = false;
						yellowKey = true;
						cyanKey = false;
						break;
					case "cyanKey":
						magentaKey = false;
						yellowKey = false;
						cyanKey = true;
						break;
					case "doorRRMagenta":
						if(yellowKey)
						{
							doorRRMagenta = true;
							//blueKeyCount--;
							yellowKey = false;
						}
						else
						{
							doorRRMagenta = false;
						}
						break;
					case "doorBRMagenta":
						if(cyanKey)
						{
							doorBRMagenta = true;
							//redKeyCount--;
							cyanKey = false;
						}
						else
						{
							doorBRMagenta = false;
						}
						break;
					case "doorRRYellow":
						if(magentaKey)
						{
							doorRRYellow = true;
							//greenKeyCount--;
							//Debug.Log ("greenKey count " +greenKeyCount);
							//Debug.Log ("greenKey " +greenKey);
							magentaKey = false;
						}
						else
						{
							doorRRYellow = false;
						}
						break;
					case "doorGRYellow":
						if(cyanKey)
						{
							doorGRYellow = true;
							cyanKey = false;
						}
						else
						{
							doorGRYellow = false;
						}
						break;
					case "doorBRCyan":
						if(magentaKey)
						{
							doorBRCyan = true;
							magentaKey = false;
						}
						else
						{
							doorBRCyan = false;
						}
						break;
					case "doorGRCyan":
						if(yellowKey)
						{
							doorGRCyan = true;
							yellowKey = false;
						}
						else
						{
							doorGRCyan = false;
						}
						break;
					}
			}
		}
	}
}
