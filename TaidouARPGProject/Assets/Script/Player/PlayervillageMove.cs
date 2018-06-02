using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayervillageMove : MonoBehaviour {

	public float velocity;
	private NavMeshAgent agent;
	void Start()
	{
		agent =this.GetComponent<NavMeshAgent>();
	}
	void Update()
	{
		Rigidbody rig = GetComponent<Rigidbody>();
		float h = Input.GetAxis("Horizontal");
		float v =Input.GetAxis("Vertical");
		Vector3 vel = rig.velocity;

		if(Mathf.Abs(h)>0.05f || Mathf.Abs(v)>0.05f)
		{
			rig.velocity= new Vector3(-h*velocity,vel.y,-v*velocity);
			
			transform.rotation =Quaternion.LookRotation(new Vector3(-h,0,-v));

		}else
		{
			if(agent.enabled == false)

			rig.velocity=Vector3.zero;

		}
		//if(agent.enabled)
		//{transform.rotation =Quaternion.LookRotation(agent.velocity);}
		
			
		
	}
	

}
