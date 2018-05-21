using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerAutoMove : MonoBehaviour {
    private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDestination(Vector3 targetPos)

    {
        agent.enabled = true;
        agent.SetDestination(targetPos);

    }

}
