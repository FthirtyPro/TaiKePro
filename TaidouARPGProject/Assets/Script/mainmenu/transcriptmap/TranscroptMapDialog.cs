using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscroptMapDialog : MonoBehaviour {

	private UILabel transcriptDes;
	private UILabel EnergyLabel;
	private UIButton BtnEnter;
	private UIButton CloseButton;

	private TweenScale tween;

	void Awake()
	{
		transcriptDes =transform.Find("Sprite/DesLabel").GetComponent<UILabel>();
		EnergyLabel =transform.Find("Sprite/EnergyLabel").GetComponent<UILabel>();
		BtnEnter =transform.Find("BtnEnter").GetComponent<UIButton>();
		CloseButton =transform.Find("BtnClose").GetComponent<UIButton>();
		
		tween =this.GetComponent<TweenScale>();

		EventDelegate ed1= new EventDelegate(this,"OnCloseButton");
		CloseButton.onClick.Add(ed1);
	}



	public void OnShow(BtnTranscript transcript)
	{
		tween.PlayForward();
		transcriptDes.text =transcript.transcriptDes;

	}

	void Desable()
	{
		tween.PlayReverse();
		
	}

		void  OnCloseButton()
	{
		tween.PlayReverse();
		
	}

	
}
