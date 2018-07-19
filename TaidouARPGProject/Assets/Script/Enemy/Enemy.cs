using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int hp =200;
	public GameObject damageEffectPrefab;
	public float attackRate=5;
	public float attackTime =0;
	public float attackDistance =2;
	public float Distance =0;
	public Animation ani;
	public float timeRate;
	public float timeLose=3;

	public float speed =2;
	public CharacterController cc;

	// Use this for initialization
private void Start() {
	cc =this.GetComponent<CharacterController>();
	ani = GetComponent<Animation>();
	//InvokeRepeating("Cal")
}
private void Update()
{
	if(hp==0){
	transform.Translate(-transform.up*0.4f*Time.deltaTime);
	timeRate+=Time.deltaTime;
	if(timeRate>=timeLose)
	Destroy(this.gameObject);

	return;
	}
	//(transform.position.y)*Time.deltaTime;

	 AttackHit();
}


void  Move()
{
	Transform play = TranscripManager._instance.player.transform;
	transform.LookAt(play);
	Vector3 pos =transform.position;
	pos.y=play.position.y;

	cc.SimpleMove(transform.forward*speed);

}

void AttackHit()
{
	Transform play = TranscripManager._instance.player.transform;
	Vector3 pos =transform.position;
	pos.y=play.position.y;
	 Distance=Vector3.Distance(play.position,pos);
	if(Distance<attackDistance)
	{
		attackTime+=Time.deltaTime;
		if(attackTime>attackRate)
		{
			ani.Play("attack01");
			attackTime =0;
		}
		if(!ani.IsPlaying("attack01"))
		{
			ani.CrossFade("idle");
		}

	}else
	{
		Move();
	}

}


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
		Comboo._instance.ComboPlus();
		int damage = int.Parse(proArray[0]);
		hp-=damage;

		//被击退位移
		float dis = float.Parse(proArray[1]);
		float jumpHeight = float.Parse(proArray[2]);
		iTween.MoveBy(this.gameObject,transform.InverseTransformDirection(TranscripManager._instance.player.transform.forward)*dis+Vector3.up*jumpHeight,0.3f);

		//播放出血特效

		GameObject.Instantiate(damageEffectPrefab,transform.position,Quaternion.identity); //实例化到当前位置。
		if(hp<=0)
		{
			Dead();
		}


	}
	void Dead()
	{
		ani.Play("die");
	}




}
