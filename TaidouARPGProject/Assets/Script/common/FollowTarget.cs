using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Vector3 offset;

    public  Transform playerBip;
    public  int smooth =2;


	// Use this for initialization
	void Start () {
        playerBip = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 carmerpos=playerBip.position + offset;
	
	transform.position =Vector3.Lerp(transform.position,carmerpos,smooth*Time.deltaTime);

	}
}
