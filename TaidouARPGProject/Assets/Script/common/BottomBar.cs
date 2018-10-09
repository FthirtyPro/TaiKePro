using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBar : MonoBehaviour {


	private UIButton CombatButton;
	private UIButton SkillButton;
	private UIButton ShopButton;
	private UIButton SystemButton;
	private UIButton TaskButton;
	private UIButton KnapsackButton;

private TweenPosition tweenPosition;

void Awake()
{
	CombatButton= transform.Find("Combat").GetComponent<UIButton>();
	SkillButton = transform.Find("Skill").GetComponent<UIButton>();
	ShopButton = transform.Find("Shop").GetComponent<UIButton>();
	SystemButton = transform.Find("System").GetComponent<UIButton>();
	TaskButton = transform.Find("Task").GetComponent<UIButton>();
	KnapsackButton = transform.Find("Knapsack").GetComponent<UIButton>();

	EventDelegate ed1 = new EventDelegate(this,"OnCombat");
	CombatButton.onClick.Add(ed1);
	EventDelegate ed2 = new EventDelegate(this,"OnSkill");
	SkillButton.onClick.Add(ed2);
	EventDelegate ed3 = new EventDelegate(this,"OnShop");
	ShopButton.onClick.Add(ed3);
	
	EventDelegate ed4 = new EventDelegate(this,"OnSystem");
	SystemButton.onClick.Add(ed4);
	
	
	EventDelegate ed5 = new EventDelegate(this,"OnTask");
	TaskButton.onClick.Add(ed5);
	
	EventDelegate ed6= new EventDelegate(this,"OnKnapsack");
	KnapsackButton.onClick.Add(ed6);
	tweenPosition = this.GetComponent<TweenPosition>();
}

void OnCombat()
{

}

void OnSkill()
{

	SkillUI._instance.tweenPosition.PlayForward();
}
void OnShop()
{

}
void OnSystem()
{

}
void OnTask()
{
	TaskUI._instance.tween.PlayForward();
}
void OnKnapsack()
{
	Knapsack._instance.Show();
}



}
