using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	private bool doorOpen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (doorOpen == true) {
			transform.Translate(new Vector3(0.0f,-0.5f,0.0f));
		}
	
	}
	//this is part of what to change for more keys
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player" && GameVariables.keyCount > 0) {
            Debug.Log("collision with player");
			GameVariables.keyCount-=1;
			doorOpen = true;
			//keyCollected += 1;
			//GameVariables.keyCount+=1;
			//Destroy(gameObject);
			
		}
	}
}
