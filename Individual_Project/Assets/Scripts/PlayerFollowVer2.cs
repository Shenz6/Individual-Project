using UnityEngine;
using System.Collections;

public class PlayerFollowVer2 : MonoBehaviour {

	private PlayerDetectionVer2 detect;
	private PatrolVer2 patrol;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		//Nav Mesh set up
		agent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Investigate(){
		
	}
	public void Chase(){
		
	}
}
