using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTranscript : MonoBehaviour {

	public int transcriptId;
	public int needLevel;
	public string sceneName;
	public string transcriptDes;
	

	 public void OnClick()
	{
		transform.parent.SendMessage("OnBtnTranscript",this);

	}

}
