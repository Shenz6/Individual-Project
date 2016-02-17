using UnityEngine;
using System.Collections;

public class PlayerDetectionVer2 : MonoBehaviour {

	private PatrolVer2 patrol;
	private PlayerFollowVer2 follow;

	private NavMeshAgent agent;
	private GameObject player;
	private GameObject enemy;

	private bool playerHidden;


	// Use this for initialization
	void Start () {
		//patrol = gameObject.GetComponent<PatrolVer2>;
		//follow = gameObject.GetComponent<PlayerFollowVer2>;
		enemy = this.gameObject;

		player = GameObject.FindGameObjectWithTag ("Player");

		agent = GetComponent<NavMeshAgent>();

		playerHidden = true;
	}
	
	// Update is called once per frame
	void Update () {

		// Bit shift the index of the layer (8) to get a bit mask
		int layerMask = 1 << 8;

		// This would cast rays only against colliders in layer 8.
		// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
		layerMask = ~layerMask;
		/*
		RaycastHit hit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
			Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * hit.distance, Color.yellow);
			Debug.Log("Did Hit");
		} else {
			Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) *1000, Color.white);
			Debug.Log("Did not Hit");
		}
		*/

		RaycastHit hit;

		//I want this to satisfy a boolean that can tell that yes the player is in sight of the enemy
		if (Physics.Linecast (enemy.transform.position, player.transform.position, out hit)) {
			if (player.GetComponent<Collider> () == hit.collider) {
				Debug.DrawLine (enemy.transform.position, player.transform.position, Color.green);
				Debug.Log ("Nothing Between player and Enemy");
				playerHidden = false;
			} else {
				Debug.DrawLine (enemy.transform.position, player.transform.position, Color.red);
				playerHidden = true;
			}
		} 

	}

	//Checking the surrounding area for the player because robots might have eyes in the back of their heads..... probably not
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
		{
			//patrol.lastKnownpPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
			//patrol.waypoint = 3;
		}
	}
}
