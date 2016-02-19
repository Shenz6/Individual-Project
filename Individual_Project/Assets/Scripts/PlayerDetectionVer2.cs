using UnityEngine;
using System.Collections;

public class PlayerDetectionVer2 : MonoBehaviour {

	private PatrolVer2 patrol;
	private PlayerFollowVer2 follow;

	private NavMeshAgent agent;
	private GameObject player;
	private GameObject enemy;

	public float FOVRange; // range of the cone 68
	public float rayRange; // distance enemy can see in front
	private float hitCount; // amound of time raycast hits player
	private Vector3 rayDirection;
	private Transform lastKnownPos; // last known position of the player

	private bool playerHidden;
	private bool playerInSight;
	private bool alert;


	// Use this for initialization
	void Start () {
		//patrol = gameObject.GetComponent<PatrolVer2>;
		//follow = gameObject.GetComponent<PlayerFollowVer2>;
		enemy = this.gameObject;

		player = GameObject.FindGameObjectWithTag ("Player");
		patrol = gameObject.GetComponent<PatrolVer2> ();
		agent = GetComponent<NavMeshAgent>();

		hitCount = 0;

		PlayerHidden ();
		PlayerOutOfSight ();
	}
	
	// Update is called once per frame
	void Update () {
		//Change status if player can be see
		if (playerHidden == false && playerInSight == true){
			patrol.StopPatrolling ();
		}


		//Below determines whether the enemy can see the player
		RaycastHit hit;

		//I want this to satisfy a boolean that can tell that yes the player is hidden behind an object and can't be seen by the enemy even if within vision cone
		if (Physics.Linecast (enemy.transform.position, player.transform.position, out hit)) {
			if (player.GetComponent<Collider> () == hit.collider) {
				//Debug.DrawLine (enemy.transform.position, player.transform.position, Color.green);
				//Debug.Log ("Nothing Between player and Enemy");
				PlayerUnHidden();
			} else {
				//Debug.DrawLine (enemy.transform.position, player.transform.position, Color.red);
				PlayerHidden();
			}
		}

		//Vision cone
		Vector3 rayDirection = player.transform.position - transform.position; // Determine the angle between player and enemy.
		//Debug.Log(Vector3.Angle (rayDirection, transform.forward));
		if ((Vector3.Angle (rayDirection, transform.forward)) <= FOVRange * 0.5f) {
			//Debug.Log ("Whithin cone");
			// Detect if player is within the field of view
			if (Physics.Raycast (transform.position, rayDirection, out hit, rayRange)) {
				if (hit.transform.tag == "Player") {
					PlayerInSight ();
					lastKnownPos.transform.position = hit.transform.position;
					hitCount += 1;
					Debug.Log ("Player in sight");
					Debug.Log (hitCount);
					Debug.DrawRay (transform.position, rayDirection, Color.cyan, rayRange);
				}
			}
		} else {
			PlayerOutOfSight ();
			Debug.DrawRay (transform.position, rayDirection, Color.yellow, rayRange);
			Debug.Log ("Player not in sight");
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
	public void Investigate(){
		transform.LookAt (lastKnownPos);
		StartCoroutine (HoldIt ());
	}
	public void Chase(){
		
	}

	IEnumerator HoldIt(){
		print(Time.time);
		yield return new WaitForSeconds(5);
		print(Time.time);
	}

	public void PlayerInSight(){
		playerInSight = true;
	}

	public void PlayerOutOfSight(){
		playerInSight = false;
	}

	public void PlayerUnHidden(){
		playerHidden = false;
	}

	public void PlayerHidden(){
		playerHidden = true;
	}
}
