using UnityEngine;
using System.Collections;

public class yellowExit1 : MonoBehaviour {

	private itemPickup iPObject;
	
	private Object[] objects;
	private Texture[] textures;
	private Material goMaterial;
	private int frameCounter = 0;
	
	public bool aniTexDone = false;
	
	void Awake()
	{
		this.goMaterial = this.renderer.material;
	}
	
	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		iPObject = playerObject.GetComponent<itemPickup> ();
		
		this.objects = Resources.LoadAll ("exitDoorGRyellow", typeof(Texture));
		this.textures = new Texture[objects.Length];
		
		for(int i=0; i < objects.Length; i++)
		{
			this.textures[i] = (Texture)this.objects[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(iPObject.doorGRYellow)
		{
			//StartCoroutine ("PlayLoop", 0.04f);
			StartCoroutine ("Play", 0.02f);
			goMaterial.mainTexture = textures [frameCounter];
		}
	}
	
	IEnumerator PlayLoop(float delay)
	{
		yield return new WaitForSeconds (delay);
		
		frameCounter = (++frameCounter) % textures.Length;
		
		StopCoroutine ("PlayLoop");
	}
	
	IEnumerator Play(float delay)
	{
		yield return new WaitForSeconds(delay);
		if(frameCounter < textures.Length-1)
		{
			++frameCounter;
		}
		else
		{
			aniTexDone = true;
		}
		//StopCoroutine ("PlayLoop");
		StopCoroutine ("Play");
	}
}
