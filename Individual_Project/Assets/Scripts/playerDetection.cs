using UnityEngine;
using System.Collections;

public class playerDetection : MonoBehaviour {
/*
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	private LastPlayerSighting lastPlayerSighting;
	private GameObject player;
	private Animator playerAnim;
	private PlayerHealth playerHealth;
	private HashIDs hash;
	private Vector3 previousSighting;

	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		anim = GetComponent<Animator> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<lastPlayerSighting> ();
		player = GameObject.FindGameObjectWithTag (Tags.player);
		playerAnim = player.GetComponent<Animator> ();
		playerHealth = player.GetComponent<playerHealth> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();

		personalLastSighting = lastPlayerSighting.resetPosition;
		previousSighting = lastPlayerSighting.resetPosition;

	}
*/
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
}
