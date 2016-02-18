using UnityEngine;
using System.Collections;

public class PatrolVer2 : MonoBehaviour {

	[SerializeField] public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;


	private bool isPatrolling;

	private PlayerDetectionVer2 detect;
	private PlayerFollowVer2 follow;

	// Use this for initialization
	void Start () {
		//Nav Mesh patrol set up
		agent = GetComponent<NavMeshAgent>();

		StartPatrolling ();

		GotoNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (agent.remainingDistance < 0.5f && isPatrolling == true)
			GotoNextPoint();
	}

	public void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}

	public void StartPatrolling ()
	{
		isPatrolling = true;
	}

	public void StopPatrolling()
	{
		isPatrolling = false;
	}
}
