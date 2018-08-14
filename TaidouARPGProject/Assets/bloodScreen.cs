using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodScreen : MonoBehaviour {

	public static bloodScreen _instance;

	public static bloodScreen Instance{
		get{
			return _instance;
		}
	}
	// Use this for initialization
	void Awake () {
		_instance =this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Show()
	{
		

	}
}
