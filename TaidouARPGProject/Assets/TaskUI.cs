using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {

private UIGrid taskListGrid;
public GameObject taskItemPrefab;
void Awake()
{
	taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
}
/// <summary>
/// 初始化任务列表
/// </summary>
/// 


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
