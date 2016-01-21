using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	
	void OnTriggerEnter(Collider collider)
	{
        Debug.Log("trigger entered");
		if (collider.gameObject.tag == "Player") {
			//keyCollected += 1;
			Debug.Log ("Collision with key");
			GameVariables.keyCount+=1;
			Destroy(gameObject);

            Debug.Log(GameVariables.keyCount);

		}
	}
}
