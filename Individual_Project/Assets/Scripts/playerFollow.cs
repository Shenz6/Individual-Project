using UnityEngine;
using System.Collections;

public class playerFollow : MonoBehaviour {

	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float EnemyMovementSpeed;
	public float damping = 1;
	public Transform fpsTarget;
	private NavMeshAgent agent;

	Rigidbody theRigidBody;
	public Renderer myRender;

	// Use this for initialization
	void Start () {


		myRender.GetComponent<Renderer> ();
		theRigidBody = GetComponent<Rigidbody>();
		agent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		fpsTargetDistance = Vector3.Distance (fpsTarget.position,transform.position);

		if (fpsTargetDistance < enemyLookDistance) {
			myRender.material.color = Color.yellow;
			lookAtPlayer();
			//print ("looking at player");
		}
		if (fpsTargetDistance < attackDistance) {
			myRender.material.color = Color.red;
			attackPlease();
			//print ("Attack");

		}
		if(fpsTargetDistance > enemyLookDistance) {
			myRender.material.color = Color.green;
		}
		*/
	}

	public void chasePlayer(){
		fpsTargetDistance = Vector3.Distance (fpsTarget.position,transform.position);
		
		if (fpsTargetDistance < enemyLookDistance) {
			//myRender.material.color = Color.yellow;
			lookAtPlayer();
			//print ("looking at player");
		}
		if (fpsTargetDistance < attackDistance) {
			//myRender.material.color = Color.red;
			attackPlease();
			//print ("Attack");
			
		}
		if(fpsTargetDistance > enemyLookDistance) {
			//myRender.material.color = Color.green;
		}
	}

	void lookAtPlayer(){

		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);

	}

	void attackPlease(){

		transform.position = Vector3.MoveTowards (transform.position, fpsTarget.transform.position, EnemyMovementSpeed);

		//theRigidBody.AddForce (transform.forward * EnemyMovementSpeed);
	
	}
}
