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

    // Update is called once per frameup
    void Update()
    {

    }

	void DisableUpdateButton(string label ="")
	{
		updateButton.SetState(UIButton.State.Disabled,true);
        //dateButton.enabled=false;
        //updateButton.SetState(UIButton.State.Hover,true);
        //pdateButton.disabledColor = Color.gray;
        updateButton.SetState(UIButtonColor.State.Disabled, true);
        if (label!="")
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



        //取得玩家身上金币数目，如果金钱，等级够才能升级，如诺不够，则不能升级。
       PlayerInfo player=PlayerInfo._instanc;
        int coin = player.Coin;

        if(500*(skill.Level+1)<=coin)
        {
            skillTitle.text = skill.Name + "LV." + skill.Level;
            skillDes.text = "当前技能攻击力为：" + skill.Damage + "*" + skill.Level + "下级攻击力";

            EnableUpdateButton("升级");
            // Debug.Log(coin);
            print(coin);
        }
        else
        {
            skillTitle.text = skill.Name + "LV." + skill.Level;
            skillDes.text = "当前技能攻击力为：" + skill.Damage + "*" + skill.Level + "下级攻击力";
            DisableUpdateButton("金币不足");
        }
		


	}

	void OnUpdateButton()
	{
        if(skill.Level<=PlayerInfo._instanc.Level)
        {
            //if(500 * (skill.Level + 1) <= PlayerInfo._instanc.Coin)
            int coinNeed = 500 * (skill.Level + 1);
            bool isSucced = PlayerInfo._instanc.GetCoin(coinNeed);
            if(isSucced)
            { skill.Upgrade();
                print(PlayerInfo._instanc.Coin);
            }
        }
        else
        {
            DisableUpdateButton("最大等级");
        }
		
	}


void OnCloseButton()
{
	tweenPosition.PlayReverse();
}


}
