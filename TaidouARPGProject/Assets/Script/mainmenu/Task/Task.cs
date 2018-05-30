using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task {

	public enum TaskType {
		Main,
		Reward,
		Daily
	}

	public enum TaskProgress {
		NoStart,
		Accept,
		Complete,
		ReWard
	}

	private int id;

	

    private TaskType taskType;
	private string name;
	private string icon;
	private string des;
	private int coin;
	private int diamond;
	private string talkNpc; //对话NPC 内容
	private int idNpc; //npc的id
	private int idTranscript; //副本id
	private TaskProgress taskProgress = TaskProgress.NoStart;


    public delegate void OnTaskChangeEvent();//委托
    public event OnTaskChangeEvent OnTaskChange;//事件


public int Id {
		get {
			return id;
		}
		set { id = value; }
	}

    public TaskType Tasktype
    {
        get
        {
            return taskType;
        }

        set
        {
            taskType = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }

    public int Coin
    {
        get
        {
            return coin;
        }

        set
        {
            coin = value;
        }
    }

    public int Diamond
    {
        get
        {
            return diamond;
        }

        set
        {
            diamond = value;
        }
    }

    public string TalkNpc
    {
        get
        {
            return talkNpc;
        }

        set
        {
            talkNpc = value;
        }
    }

    public int IdNpc
    {
        get
        {
            return idNpc;
        }

        set
        {
            idNpc = value;
        }
    }

    public int IdTranscript
    {
        get
        {
            return idTranscript;
        }

        set
        {
            idTranscript = value;
        }
    }

    public TaskProgress Taskprogress
    {
        get
        {
            return taskProgress;
        }

        set
        {
            if(taskProgress!=value)
            {
            taskProgress = value;
            OnTaskChange();
                
            }
        }
    }

    //构造方法完成；
    ///任务类的完成；
}