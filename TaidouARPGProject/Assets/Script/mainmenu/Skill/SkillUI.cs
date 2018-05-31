using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{

    private UILabel skillTitle;
    private UILabel skillDes;
    private UIButton closeButton;
    private UIButton updateButton;
    private UILabel updateLabel;

    // Use this for initialization
    void Awake()
    {
        skillTitle = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDes = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        updateButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        updateLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();
		skillTitle.text ="";
		
		skillDes.text ="";
		
		DisableUpdateButton("选择技能");
		EventDelegate ed1= new EventDelegate(this,"OnUpdateButton");
		updateButton.onClick.Add(ed1);
		


    }

    // Update is called once per frame
    void Update()
    {

    }

	void DisableUpdateButton(string label ="")
	{
		updateButton.SetState(UIButton.State.Disabled,true);
		updateButton.enabled=false;
		if(label!="")
		{
			updateLabel.text =label;
		}
	}


	void EnableUpdateButton(string label ="")
	{

		updateButton.SetState(UIButton.State.Normal,true);
		updateButton.enabled= true;

		if(label!="")
		{
			updateLabel.text =label;
		}
	}

	void OnSkillClick(Skill skill)
	{

	}

	void OnUpdateButton()
	{
		
	}



}
