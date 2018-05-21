using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayervillageMove : MonoBehaviour {

	public float velocity;

	void Update()
	{
		Rigidbody rig = GetComponent<Rigidbody>();
		float h = Input.GetAxis("Horizontal");
		float v =Input.GetAxis("Vertical");
		Vector3 vel = rig.velocity;
		rig.velocity= new Vector3(-h*velocity,vel.y,-v*velocity);


<<<<<<< HEAD:TaidouARPGProject/Assets/Script/Player/PlayerMove.cs
		if(Mathf.Abs(h)>0.05f || Mathf.Abs(v)>0.05f)
		{
			transform.rotation =Quaternion.LookRotation(new Vector3(-h,0,-v));
		}
=======
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
        }
        
      
>>>>>>> c95ecb869e4f7e7b2ba88ee45d79b7b6503b796f:TaidouARPGProject/Assets/Script/Player/PlayervillageMove.cs
	}

}
