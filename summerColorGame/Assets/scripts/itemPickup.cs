using UnityEngine;
using System.Collections;

public class itemPickup : MonoBehaviour {
	public bool redLens = false;
	public bool greenLens = false;
	public bool blueLens = false;
	public bool redKey = false;
	public bool greenKey = false;
	public bool blueKey = false;
	public bool doorMagenta = false;
	public bool doorBRMagenta = false;
	public bool doorYellow = false;
	public bool doorGRYellow = false;
	public bool doorCyan = false;

	private int redKeyCount = 0;
	private int greenKeyCount = 0;
	private int blueKeyCount = 0;

	//GameObject rKObject = GameObject.Find;
	//GameObject gKObject = GameObject.Find ("RRgreenKey");
	//GameObject bKObject = GameObject.Find ("RRblueKey");

	// Use this for initialization
	void Start () {
		//GameObject rKObject = GameObject.FindGameObjectWithTag ("redKey");
		//GameObject gKObject = GameObject.FindGameObjectWithTag ("greenKey");
		//GameObject bKObject = GameObject.FindGameObjectWithTag ("blueKey");
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.mainCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		Debug.DrawRay (ray.origin, ray.direction * 10, Color.cyan);
		RaycastHit hit;

		//Debug.Log ("Red Key " +redKey);
		//Debug.Log ("Green Key " +greenKey);
		//Debug.Log ("Blue Key " +blueKey);

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
					case "redKey":
						redKey = true;
						blueKey = false;
						greenKey = false;
						redKeyCount++;
						//hit.transform.gameObject.renderer.enabled = false;
						//GameObject.FindGameObjectWithTag("redKey").renderer.enabled = false;
						//gKObject.renderer.enabled = true;
						//bKObject.renderer.enabled = true;
						//GameObject.FindGameObjectWithTag("blueKey").renderer.enabled = true;
						//Destroy(hit.transform.gameObject);
						break;
					case "blueKey":
						redKey = false;
						blueKey = true;
						greenKey = false;
						blueKeyCount++;
						//hit.transform.gameObject.renderer.enabled = false;
						//gKObject.renderer.enabled = true;
						//rKObject.renderer.enabled = true;
						//GameObject.FindGameObjectWithTag("redKey").renderer.enabled = true;
						//GameObject.FindGameObjectWithTag("greenKey").renderer.enabled = true;
						//GameObject.FindGameObjectWithTag("blueKey").renderer.enabled = false;
						//Destroy(hit.transform.gameObject);
						break;
					case "greenKey":
						redKey = false;
						blueKey = false;
						greenKey = true;
						greenKeyCount++;
						//hit.transform.gameObject.renderer.enabled = false;
						//rKObject.renderer.enabled = true;
						//bKObject.renderer.enabled = true;
						//GameObject.FindGameObjectWithTag("redKey").renderer.enabled = true;
						//GameObject.FindGameObjectWithTag("greenKey").renderer.enabled = false;
						//GameObject.FindGameObjectWithTag("blueKey").renderer.enabled = true;
						//Debug.Log ("greenKey count " +greenKeyCount);
						//Destroy(hit.transform.gameObject);
						break;
					case "doorMagenta":
						if(blueKey)
						{
							doorMagenta = true;
							blueKeyCount--;
							//if(blueKeyCount < 1)
							//{
								blueKey = false;
							//}
						}
						else
						{
							doorMagenta = false;
						}
						break;
					case "doorBRMagenta":
						if(redKey)
						{
							doorBRMagenta = true;
							redKeyCount--;
							//if(redKeyCount < 1)
							//{
								redKey = false;
							//}
						}
						else
						{
							doorBRMagenta = false;
						}
						break;
					case "doorYellow":
						if(greenKey)
						{
							doorYellow = true;
							greenKeyCount--;
							Debug.Log ("greenKey count " +greenKeyCount);
							//if(greenKeyCount < 1)
							//{
								Debug.Log ("greenKey " +greenKey);
								greenKey = false;
							//}
						}
						else
						{
							doorYellow = false;
						}
						break;
					case "doorGRYellow":
						if(greenKey)
						{
							doorGRYellow = true;
							greenKeyCount--;
							Debug.Log ("greenKey count " +greenKeyCount);
							if(greenKeyCount < 1)
							{
								Debug.Log ("greenKey " +greenKey);
								greenKey = false;
							}
						}
						else
						{
							doorGRYellow = false;
						}
						break;
					case "doorCyan":
						if(redKey)
						{
							doorCyan = true;
							redKeyCount--;
							if(redKeyCount < 1)
							{
								redKey = false;
							}
						}
						else
						{
							doorCyan = false;
						}
						break;
					case "doorBRCyan":
						if(redKey)
						{
							doorCyan = true;
							redKeyCount--;
							if(redKeyCount < 1)
							{
								redKey = false;
							}
						}
						else
						{
							doorCyan = false;
						}
						break;
					}
			}
		}
	}
}
