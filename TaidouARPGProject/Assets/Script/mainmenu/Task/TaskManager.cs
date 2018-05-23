using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : MonoBehaviour {

public static TaskManager _instance;
private Task currentTask;

public TextAsset taskinfoText;
private ArrayList taskList=new ArrayList();
private PlayerNav playAutorun;




private PlayerNav PlayAutorun{

	get{
		if(playAutorun ==null)
		{
			playAutorun =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerNav>();
		}
		return playAutorun;
	}
}

void Awake()
{
	_instance =this;
	InitTask();

}



/// <summary>
/// 初始化任务信息列表
/// </summary>
 public void InitTask()
 {
	 string[] taskArray = taskinfoText.ToString().Split('\n');
	 foreach(string strArr in taskArray)
	 {
		 string[] proArray = strArr.Split('|');
		 Task task = new Task();
		 task.Id =int.Parse(proArray[0]);
			switch(proArray[1])
			{
				case "Main":
				task.Tasktype = Task.TaskType.Main;
				break;
				case "Reward":
				task.Tasktype =Task.TaskType.Reward;
				break;
				case "Daily":
				task.Tasktype =Task.TaskType.Daily;
				break;
				
			}

		 task.Name = proArray[2];
		 task.Icon = proArray[3];
		 task.Des  = proArray[4];
		 task.Coin = int.Parse(proArray[5]);
		 task.Diamond =int.Parse(proArray[6]);
		 task.TalkNpc =proArray[7];
		 task.IdNpc =int.Parse (proArray[8]);
		 task.IdTranscript = int.Parse(proArray[9]);
			taskList.Add(task);

	 }
 }


	//方法得到tasklist
	public ArrayList GetTaskList()
	{
		return taskList;
	}

	public void OnExecuteTask(Task task)
	{
		currentTask = task;
		if(task.Taskprogress == Task.TaskProgress.NoStart )
		{
			TaskUI._instance.tween.PlayReverse();
			
			PlayAutorun.SetDestination(NPCManager._instance.GetNpcById(task.IdNpc).transform.position);
		
		}else if(task.Taskprogress == Task.TaskProgress.Accept )
			{
				PlayAutorun.SetDestination(NPCManager._instance.transcriptGo.transform.position);
			}

	}



	public void OnAcceptTask()
	{

	}
	public void OnArrivedPos()
	{
		

	}

}
