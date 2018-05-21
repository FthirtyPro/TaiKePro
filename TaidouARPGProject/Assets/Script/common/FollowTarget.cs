using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Vector3 offset;
<<<<<<< HEAD
    public  Transform playerBip;
=======
    public Transform playerBip;
>>>>>>> c95ecb869e4f7e7b2ba88ee45d79b7b6503b796f

	// Use this for initialization
	void Start () {
        playerBip = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerBip.position + offset;
	}
}
