using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {
public static TaskUI _instance;
private UIButton CloseButton;
private UIGrid taskListGrid;
public GameObject taskItemPrefab;
public TweenPosition tween;
void Awake()
{
	_instance =this;
	taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
	CloseButton = transform.Find("CloseButton").GetComponent<UIButton>();
	tween = gameObject.GetComponent<TweenPosition>();

	EventDelegate ed1 = new EventDelegate(this,"CloseTaskUI");
	CloseButton.onClick.Add(ed1);
	

}
/// <summary>
/// 初始化任务列表
/// </summary>
/// 

 void CloseTaskUI()
 {
	 tween.PlayReverse();
 }
void Start()
{
	InitTaskList();
}
void InitTaskList()
{
	ArrayList taskList = TaskManager._instance.GetTaskList();

	foreach(Task task in taskList)
	{
		GameObject go = NGUITools.AddChild(taskListGrid.gameObject,taskItemPrefab);

		taskListGrid.AddChild(go.transform, true);//对新添加的任务进行排序

		TaskItemUI ti = go.GetComponent<TaskItemUI>();
		ti.SetTask(task);
	}
}

}
