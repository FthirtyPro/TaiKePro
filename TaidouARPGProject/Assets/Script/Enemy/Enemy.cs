using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int hp =200;
	public GameObject damageEffectPrefab;
	// Use this for initialization
	void TakeDamge(string agrs)
	{
		// 1.受伤动画
		// 2.伤害值
		// 3，后退值
		// 4，浮空值

		


		string[] proArray = agrs.Split(',');
		//受伤动画
	    
		this.GetComponent<Animation>().Play("takedamage");


		//减血量
	
		if(hp<=0)
		return;
		int damage = int.Parse(proArray[0]);
		hp-=damage;

		//被击退位移
		float dis = float.Parse(proArray[1]);
		float jumpHeight = float.Parse(proArray[2]);
		iTween.MoveBy(this.gameObject,transform.InverseTransformDirection(TranscripManager._instance.player.transform.forward)*dis+Vector3.up*jumpHeight,0.3f);

		//播放出血特效

		GameObject.Instantiate(damageEffectPrefab,transform.position,Quaternion.identity); //实例化到当前位置。


	}




}
