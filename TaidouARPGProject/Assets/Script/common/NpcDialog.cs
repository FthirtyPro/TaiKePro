using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialog : MonoBehaviour {

	private TweenPosition tween;
	private UILabel npcTalkLable;
	private UIButton acceptButton;


	 public static NpcDialog _instance;

	 void Awake()
	 {
		 _instance =this;
	 }

	void Start () {
		tween = this.GetComponent<TweenPosition>();
		npcTalkLable =transform.Find("Label").GetComponent<UILabel>();
		acceptButton =transform.Find("AcceptButton").GetComponent<UIButton>();

		EventDelegate ed1 = new EventDelegate(this,"OnAccept");
		acceptButton.onClick.Add(ed1);

		
	}
	
	
	void Update () {
		
	}


	void OnAccept()
	{
		TaskManager._instance.OnAcceptTask();
		tween.PlayReverse();
	}

	public void Show(string NpcTalk )
	{
		npcTalkLable.text =NpcTalk;
		tween.PlayForward();
	}
}
