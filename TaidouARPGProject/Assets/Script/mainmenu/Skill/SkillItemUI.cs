using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemUI : MonoBehaviour
{

    public PosType postype;
    private Skill skill;

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
	}

	void updateShow()
	{
		skill= SkillManager._instance.GetSkillbyPosition(postype);
		Sprite.spriteName = skill.Icon;


	}



}
