using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVillageAnimation : MonoBehaviour {


	public Animator ani;
	// Use this for initialization
	void Start () {
		ani =this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rig =gameObject.GetComponent<Rigidbody>();
		
		if(rig.velocity.magnitude>0.5f)
		{
			ani.SetBool("Move",true);
		}
		else{
			ani.SetBool("Move",false);
			
		}
	}
}
