using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatar : MonoBehaviour {
	private Rigidbody rig;
	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		rig = this.GetComponent<Rigidbody>();
			if(rig.velocity.magnitude>0.8f)
			{
				ani.SetBool("move",true);

			}else
			{
				ani.SetBool("move",false);
			}

	}
}
