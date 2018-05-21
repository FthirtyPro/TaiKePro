using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour {
 

	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(agent.enabled)
		{
			if(agent.remainingDistance<3)
			{
				//agent.isStopped();
				agent.enabled =false;
			}
		}


	}

	public void SetDestination(Vector3 tagpos)
	{
		agent.enabled =true;
		agent.SetDestination(tagpos);
	}
}
