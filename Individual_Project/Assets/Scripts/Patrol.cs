using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public GameObject patrol1;
	public GameObject patrol2;
	public Vector3 target;
	public Vector3 playerPos;
	
	public float moveSpeed;
	public float rotationSpeed;

	private int waypoint = 1;
	private float cooldown = 100f;
	public float cooldownReset = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*

		if (waypoint == 1) {
			target = new Vector3(patrol2.transform.position.x , patrol2.transform.position.y ,patrol2.transform.position.z);
			//target.transform = patrol2.transform;
		}
		else if (waypoint == 2) {
			target = new Vector3(patrol1.transform.position.x , patrol1.transform.position.y ,patrol1.transform.position.z);
			//target.transform = patrol1.transform;
		}

		playerPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

		if (Vector3.Distance(playerPos, target) < 2.5f ) {

			if (waypoint == 1){
				waypoint = 2;
				Debug.Log ("waypoint changed to 2");
			}
			else if (waypoint == 2){
				waypoint = 1;
				Debug.Log ("waypoint changed to 1");
			}

			cooldown = cooldownReset;

			if(cooldown >  1){
			//rotate to look at the waypoint
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), rotationSpeed * Time.deltaTime);
			}
			if(cooldown < 1){
			//move towards the waypoint
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
			}
		}
		else if (Vector3.Distance(playerPos, target) > 2.5f ){

			//rotate to look at the waypoint
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), rotationSpeed * Time.deltaTime);

			//move towards the waypoint
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
		}

	*/
	
	}


	public void patrolling(){

		if (waypoint == 1) {
			target = new Vector3(patrol2.transform.position.x , patrol2.transform.position.y ,patrol2.transform.position.z);
			//target.transform = patrol2.transform;
		}
		else if (waypoint == 2) {
			target = new Vector3(patrol1.transform.position.x , patrol1.transform.position.y ,patrol1.transform.position.z);
			//target.transform = patrol1.transform;
		}
		
		playerPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		
		if (Vector3.Distance(playerPos, target) < 2.5f ) {
			
			if (waypoint == 1){
				waypoint = 2;
				Debug.Log ("waypoint changed to 2");
			}
			else if (waypoint == 2){
				waypoint = 1;
				Debug.Log ("waypoint changed to 1");
			}
			
			cooldown = cooldownReset;
			
			if(cooldown >  1){
				//rotate to look at the waypoint
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), rotationSpeed * Time.deltaTime);
			}
			if(cooldown < 1){
				//move towards the waypoint
				transform.position += transform.forward * Time.deltaTime * moveSpeed;
			}
		}
		else if (Vector3.Distance(playerPos, target) > 2.5f ){
			
			//rotate to look at the waypoint
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), rotationSpeed * Time.deltaTime);
			
			//move towards the waypoint
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
		}
	}

}
