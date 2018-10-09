using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarManager : MonoBehaviour {

	public static HpBarManager _instance;
	public GameObject hpBarPrefab;
	public GameObject hubtext;
	

	void Awake()
	{
		_instance=this;
	}

	public GameObject GetHpBar(GameObject target)
	{
		GameObject go =NGUITools.AddChild(this.gameObject,hpBarPrefab);
		go.GetComponent<UIFollowTarget>().target=target.transform;
		return go;
	}


	
	public GameObject GetHubtext(GameObject target)
	{
		GameObject go =NGUITools.AddChild(this.gameObject,hubtext);
		go.GetComponent<UIFollowTarget>().target=target.transform;
		return go;
	}
}
