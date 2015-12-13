using UnityEngine;
using System.Collections;

public class playerDetection : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;

	//private LastPlayerSighting lastPlayerSighting;
	private GameObject player;

	//private PlayerHealth playerHealth;
	//private HashIDs hash;
	//private Vector3 previousSighting;

	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		//anim = GetComponent<Animator> ();
		//lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<lastPlayerSighting> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		//playerAnim = player.GetComponent<Animator> ();
		//playerHealth = player.GetComponent<playerHealth> ();
		//hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();

		//personalLastSighting = lastPlayerSighting.resetPosition;
		//previousSighting = lastPlayerSighting.resetPosition;

	}

	// Use this for initialization
	void Start () {
	
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
			print (theDistance + " " + hit.collider.gameObject.name);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == player)
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;

				if(Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					if(hit.collider.gameObject == player)
					{
						playerInSight = true;

						//GO TO THE CHASE SCRIPT HERE
					}
				}
			}

		}

	}
	void onTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			playerInSight = false;
		}
	}





}
