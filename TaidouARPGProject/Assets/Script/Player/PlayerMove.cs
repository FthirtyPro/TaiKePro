using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float velocity;

	void Update()
	{
		Rigidbody rig = GetComponent<Rigidbody>();
		float h = Input.GetAxis("Horizontal");
		float v =Input.GetAxis("Vertical");
		Vector3 vel = rig.velocity;
		rig.velocity= new Vector3(-h*velocity,vel.y,-v*velocity);


		if(Mathf.Abs(h)>0.05f || Mathf.Abs(v)>0.05f)
		{
			transform.rotation =Quaternion.LookRotation(new Vector3(-h,0,-v));
		}
	}

}
