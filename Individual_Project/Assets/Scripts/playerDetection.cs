using UnityEngine;
using System.Collections;

public class playerDetection : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;
	public Renderer myRender;

	private NavMeshAgent nav;
	private SphereCollider col;

	//private LastPlayerSighting lastPlayerSighting;
	private GameObject player;

	//private PlayerHealth playerHealth;
	//private HashIDs hash;
	//private Vector3 previousSighting;

	private playerFollow chase;
	private Patrol patrol;
	private bool isOnPatrol = true;
	private bool isGreen = true;

	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		chase = gameObject.GetComponent<playerFollow> ();
		patrol = gameObject.GetComponent<Patrol> ();
		myRender.GetComponent<Renderer> ();
		//anim = GetComponent<Animator> ();
		//lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<lastPlayerSighting> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		//playerAnim = player.GetComponent<Animator> ();
		//playerHealth = player.GetComponent<playerHealth> ();
		//hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();

		//personalLastSighting = lastPlayerSighting.resetPosition;
		//previousSighting = lastPlayerSighting.resetPosition;
		myRender.material.color = Color.green;
	

	}

	// Use this for initialization
	void Start () {

		myRender.material.color = Color.green;
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		float theDistance;
		// debug raycast 
		Vector3 forward = transform.TransformDirection (Vector3.forward) *10;
		Debug.DrawRay(transform.position,forward,Color.green);

		if(Physics.Raycast(transform.position,(forward), out hit)){
			theDistance = hit.distance;
			//print (theDistance + " " + hit.collider.gameObject.name);
		}

		if (isOnPatrol == true) {
			patrol.patrolling();
		}
	

	}

	void OnTriggerStay (Collider other)
	{
		if (isGreen == true) {
			myRender.material.color = Color.green;
		}

		if (other.gameObject == player)
		{
			playerInSight = false;
			Debug.Log("player entered collider");
			isGreen = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);
			isOnPatrol = true;

			myRender.material.color = Color.yellow;

			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;
				Debug.Log("player entered field of vision");

				isOnPatrol = true;

				if(Physics.Raycast (transform.position/* + transform.up*/, direction.normalized, out hit, col.radius))
				{
					isOnPatrol = true;
					if(hit.collider.gameObject == player)
					{
						isOnPatrol = false;

						myRender.material.color = Color.red;

						playerInSight = true;
						Debug.Log ("player Seen");

						//GO TO THE CHASE SCRIPT HERE

						chase.chasePlayer();
					}
				}
			}

		}

	}
	void onTriggerExit (Collider other)
	{
		if (other.gameObject == player) {

			Debug.Log("player left collider");
			playerInSight = false;

		}
		Debug.Log("player left collider outside if");


		isOnPatrol = true;
	}





}
