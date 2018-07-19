using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comboo : MonoBehaviour {


	public static Comboo _instance;
	public float comboTime =2;
	private int comboCount =0;
	private float timer =0;
	

	void Awake()
	{
		_instance =this;
		this.gameObject.SetActive(false);
	}
	void Start () {

	}

 void Update()
 {
	 timer-=Time.deltaTime;
	 if(timer<=0)
	 {
		 this.gameObject.SetActive(false);
		 comboCount=0;
	 }
 }

	
	public void ComboPlus()
	{
		this.gameObject.SetActive(true);
		timer =comboTime;
		comboCount++;
	}
}
