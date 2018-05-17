using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization

	public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
	
		Rigidbody rig =gameObject.GetComponent<Rigidbody>();
			Vector3  vel =rig.velocity;
		rig.velocity =new Vector3(-h*speed,vel.y,-v*speed);
		

	}
}
