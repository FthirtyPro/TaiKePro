using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private Dictionary<string,PlayEffect> effectDict =new Dictionary<string,PlayEffect>();

	void Start(){
		PlayEffect[] peArray = this.GetComponentsInChildren<PlayEffect>();

		foreach(PlayEffect pe in peArray)
		{
			effectDict.Add(pe.name,pe);
			print(pe.name);


		}

	}



	public void Attack (string args)
	{
		string[] proArray = args.Split(',');
		string effectName = proArray[1];
		ShowPlayEffect(effectName);

		//2声音
		string audioName =proArray[2];
		SoundManager._instance.Play("attack1");
		//3，前冲

		float MoveDis= float.Parse(proArray[3]);
			

		if(MoveDis>0.1f)
		{
			iTween.MoveBy(this.gameObject,Vector3.forward*MoveDis,0.3f);
			print(MoveDis);
			
		}

			//print(effectName);

	}

	public void ShowPlayEffect(string effectName)
	{
		PlayEffect pe;
		if(effectDict.TryGetValue(effectName,out pe))
		{
		
			pe.Show();
			//特效显示出来；
		}
		


	}
}
