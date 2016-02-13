using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public AudioClip clip;

	
	void OnTriggerEnter(Collider collider)
	{
        Debug.Log("trigger entered");
		if (collider.gameObject.tag == "Player") {
			//keyCollected += 1;
			Debug.Log ("Collision with key");
			GameVariables.keyCount+=1;

            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
            AudioSource.PlayClipAtPoint(clip, GameObject.FindWithTag("Player").transform.position);

			Destroy(gameObject);

            Debug.Log(GameVariables.keyCount);

		}
	}
}
