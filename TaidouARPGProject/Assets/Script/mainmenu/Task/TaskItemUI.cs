using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItemUI : MonoBehaviour {

	private UISprite tasktypeSprite;
	private UISprite iconSprite;
	private UILabel nameLabel;
	private UILabel desLabel;
	private UISprite reward1Sprite;
	private UILabel reward1Label;
	private UISprite reward2Sprite;
	private UILabel reward2Label;
	private UIButton rewardButton;
	private UIButton combatButton;
	private UILabel combatLabel;

	private Task task;

	void Awake()
	{
		tasktypeSprite = transform.Find("TaskTypeSprite").GetComponent<UISprite>();
		iconSprite = transform.Find("IconBg/Sprite").GetComponent<UISprite>();
		nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
		desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
		reward1Sprite = transform.Find("Reward1Sprite").GetComponent<UISprite>();
		reward1Label = transform.Find("Reward1Label").GetComponent<UILabel>();
		
		reward2Sprite = transform.Find("Reward12prite").GetComponent<UISprite>();
		reward2Label = transform.Find("Reward2Label").GetComponent<UILabel>();
		
		rewardButton =transform.Find("RewardButton").GetComponent<UIButton>();
		combatButton =transform.Find("CombatButton").GetComponent<UIButton>();

		combatLabel = transform.Find("CombatButton/CombatLabel").GetComponent<UILabel>();
		
		
	}


       public void SetTask(Task task)
	   {
		   this.task = task;
		   switch(task.Tasktype)
		   {
			   case Task.TaskType.Main:

			   tasktypeSprite.spriteName ="pic_主线";
			   break;
			   case Task.TaskType.Reward:
			   tasktypeSprite.spriteName ="pic_奖赏";
			   
			break;
				   case Task.TaskType.Daily:
			   tasktypeSprite.spriteName ="pic_日常";
			   
			break;
			   

 


		   }



	   }





}
