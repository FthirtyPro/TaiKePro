using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrascripMap : MonoBehaviour {

	//private BtnTranscript bt
	// Use this for initialization
	private TweenScale dialog;
	
	void Start () {
		dialog = transform.Find("TranscriptMapDialog").GetComponent<TweenScale>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBtnTranscript(BtnTranscript transcript)
	{	
		PlayerInfo info = PlayerInfo._instanc;
		if(info.Level>transcript.needLevel)
		{
			dialog.PlayForward();
		}

	}


}
