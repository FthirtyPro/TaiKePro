using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{

	public static SkillUI _instance;
    private UILabel skillTitle;
    private UILabel skillDes;
    private UIButton closeButton;
    private UIButton updateButton;
    private UILabel updateLabel;
	public TweenPosition tweenPosition;


	private Skill skill;

    // Use this for initialization
    void Awake()
    {

		_instance= this;
        skillTitle = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDes = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        updateButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        updateLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();
		skillTitle.text ="";

		tweenPosition = this.GetComponent<TweenPosition>();
		
		skillDes.text ="";
		
		DisableUpdateButton("选择技能");
		//检测升级按钮
		EventDelegate ed1= new EventDelegate(this,"OnUpdateButton");
		updateButton.onClick.Add(ed1);
		EventDelegate ed2 = new EventDelegate(this,"OnCloseButton");
		closeButton.onClick.Add(ed2);


    }

    // Update is called once per frame
    void Update()
    {

    }

	void DisableUpdateButton(string label ="")
	{
		updateButton.SetState(UIButton.State.Disabled,true);
		updateButton.enabled=false;
		updateButton.SetState(UIButton.State.Hover,true);
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

	public void OnSkillClick(Skill skill)
	{
		this.skill = skill;






		skillTitle.text = skill.Name +"LV."+skill.Level;
		skillDes.text ="当前技能攻击力为："+skill.Damage + "*" +skill.Level+"下级攻击力";
		
		EnableUpdateButton("升级");


	}

	void OnUpdateButton()
	{
		
	}


void OnCloseButton()
{
	tweenPosition.PlayReverse();
}


}
