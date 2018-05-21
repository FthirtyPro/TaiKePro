using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVillageAnimatorl : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rig = this.GetComponent<Rigidbody>();
        if (rig.velocity.magnitude>0.5f)
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
		
	}
}
