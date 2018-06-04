using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemUI : MonoBehaviour
{

    public PosType postype;
    private Skill skill;
    public bool isSelect;

    private UISprite sprite;
    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite;
        }
    }


	void Start()
	{
		updateShow();
        if(isSelect)
        {
            OnClick();
        }
	}

	void updateShow()
	{
		skill= SkillManager._instance.GetSkillbyPosition(postype);
		Sprite.spriteName = skill.Icon;


	}

    void OnClick()
    {
       
            transform.parent.parent.SendMessage("OnSkillClick",skill);
      
    }



}
