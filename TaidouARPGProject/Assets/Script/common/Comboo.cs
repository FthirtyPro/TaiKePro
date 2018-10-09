using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comboo : MonoBehaviour {


	public static Comboo _instance;
	public float comboTime =2;
	private int comboCount =0;
	private float timer =0;
	private UILabel number;
	

	void Awake()
	{
		_instance =this;
		this.gameObject.SetActive(false);
	}
	void Start () {
		number =transform.Find("NumberLabel").GetComponent<UILabel>();
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
		number.text=comboCount.ToString();

		transform.localScale=Vector3.one;

		iTween.ScaleTo(this.gameObject,new Vector3(1.5f,1.5f,1.5f),0.1f);
		iTween.ShakePosition(this.gameObject,new Vector3(0.2f,0.2f,0.2f),0.2f);
	}
}
