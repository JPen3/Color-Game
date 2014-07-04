using UnityEngine;
using System.Collections;

public class roomsLoaded : MonoBehaviour {
	private bool redRoom = false;
	private bool blueRoom = false;
	private bool greenRoom = false;

	private bool redLock = false;
	private bool blueLock = false;
	private bool greenLock = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setRedRoom(bool red)
	{
		redRoom = red;
	}

	public void setGreenRoom(bool green)
	{
		greenRoom = green;
	}

	public void setBlueRoom(bool blue)
	{
		blueRoom = blue;
	}

	public void setRedLock(bool red)
	{
		redLock = red;
	}
	
	public void setGreenLock(bool green)
	{
		greenLock = green;
	}
	
	public void setBlueLock(bool blue)
	{
		blueLock = blue;
	}

	public bool getRedRoom()
	{
		return redRoom;
	}

	public bool getGreenRoom()
	{
		return greenRoom;
	}

	public bool getBlueRoom()
	{
		return blueRoom;
	}

	public bool getRedLock()
	{
		return redLock;
	}
	
	public bool getGreenLock()
	{
		return greenLock;
	}
	
	public bool getBlueLock()
	{
		return blueLock;
	}
}
