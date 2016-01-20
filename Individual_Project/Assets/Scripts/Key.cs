using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	
	void onTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			//keyCollected += 1;
			Debug.Log ("Collision with key");
			GameVariables.keyCount+=1;
			Destroy(gameObject);

		}
	}
}
