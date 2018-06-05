using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	private Animator animator;
private float velocty =5;
private Rigidbody rig;
void Awake()
{
	rig = this.GetComponent<Rigidbody>();
	animator = this.GetComponent<Animator>();
}
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 nowVel = rig.velocity;
		if(Mathf.Abs(h)>0.05f ||Mathf.Abs(v)>0.05f )
		{
			rig.velocity = new Vector3(velocty*h,0,velocty*v);
			transform.LookAt(new Vector3(h,0,v)+transform.position);
			animator.SetBool("Move",true);
		}else{
			rig.velocity = new Vector3(0,0,0);
			animator.SetBool("Move",false);
			
			
		}
	}
}
