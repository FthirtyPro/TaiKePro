using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Dictionary<string, PlayEffect> effectDict = new Dictionary<string, PlayEffect>();
    public PlayEffect[] effect;
    public float DisForward = 2;
    public float DisAround = 2;
    public int[] damage = new int[] { 10, 20, 30, 40 };
    private UISlider hpbarSlider;

	private GameObject hudTextGameObject;
	private GameObject hpbarGameObject;
	private HUDText hudtext;
    private int hptotal =200;

    private Animator playani;

    //暂时性血量

    public int hp =100;

    private GameObject HpPoint;



	private GameObject hudtextGameObject;
    public enum AttackRang
    {
        forWard,
        around
    }

    void Start()
    {
        PlayEffect[] peArray = this.GetComponentsInChildren<PlayEffect>();


        foreach (PlayEffect pe in peArray)
        {
            effectDict.Add(pe.name, pe);



        }
        foreach (PlayEffect pe in effect)
        {
            effectDict.Add(pe.gameObject.name, pe);
            //print(pe.gameObject.name);
        }

        Transform hpbarpoint =transform.Find("HpPoint");
        hpbarGameObject=HpBarManager._instance.GetHpBar(hpbarpoint.gameObject);
        hpbarSlider =hpbarGameObject.transform.Find("Bg").GetComponent<UISlider>();


	    hudtextGameObject =HpBarManager._instance.GetHubtext(hpbarpoint.gameObject);
	    hudtext= hudtextGameObject.GetComponent<HUDText>();
        playani = this.GetComponent<Animator>();


    }

    void Update()
    {
        //GetEnemyInAttackRang(attackRange);
    }



    public void Attack(string args)
    {
        string[] proArray = args.Split(',');
        string effectName = proArray[1];
        ShowPlayEffect(effectName);

        //2声音
        //string audioName = proArray[2];
       // SoundManager._instance.Play(audioName);
        //3，前冲

        float MoveDis = float.Parse(proArray[3]);


        if (MoveDis > 0.1f)
        {
            iTween.MoveBy(this.gameObject, Vector3.forward * MoveDis, 0.3f);
            print(MoveDis);

        }


        // 普通或技能                                   攻击敌人
        string attacks = proArray[0];
        if (attacks == "normal")
        {
            ArrayList arrayList = GetEnemyInAttackRang(AttackRang.forWard);
            foreach (GameObject go in arrayList)
            {

                go.SendMessage("TakeDamge", damage[0] + "," + proArray[3] + "," + proArray[4]);

                //\\\\这里就处理敌人的事件响应
            }
        }
         else if (attacks == "skill1")
        {
            ArrayList arrayList = GetEnemyInAttackRang(AttackRang.forWard);
            foreach (GameObject go in arrayList)
            {

                go.SendMessage("TakeDamge", damage[0] + "," + proArray[3] + "," + proArray[4]);

                //\\\\这里就处理敌人的事件响应
            }
        }



    }

    public void ShowPlayEffect(string effectName)
    {
        PlayEffect pe;
        if (effectDict.TryGetValue(effectName, out pe))
        {

            pe.Show();
            //特效显示出来；
        }

    }

//添加在事件当中的显示暴击特效

    public void ShowPlayDevilEffect()
    {
        string effectName="DevilHandMobile";
        PlayEffect pe;
       effectDict.TryGetValue(effectName, out pe);
        ArrayList arrayList = GetEnemyInAttackRang(AttackRang.forWard);
        foreach(GameObject go in arrayList)
        {
            bool colldier;
            RaycastHit hit;
            colldier=Physics.Raycast(go.transform.position+Vector3.up,Vector3.up,out  hit,10f,LayerMask.GetMask("Ground"));
           if(colldier)
           {
            GameObject.Instantiate(pe,hit.point,Quaternion.identity);

           }
             GameObject.Instantiate(pe,go.transform.position,Quaternion.identity);
        }
      
    }


    public ArrayList GetEnemyInAttackRang(AttackRang attackRange)
    {
        ArrayList arrayList = new ArrayList();
        if (attackRange == AttackRang.forWard)
        {
            foreach (GameObject go in TranscripManager._instance.enemyList)
            {
                Vector3 postion = Vector3.zero;
                //把怪物的坐标转换成局部坐标。
                postion = transform.InverseTransformPoint(go.transform.position);
                if (postion.z > -0.5f) //判断是否在角色前方
                {
                    float dis = Vector3.Distance(go.transform.position, this.transform.position);
                   // print(dis);
                    if (dis < DisForward)
                    {
                        arrayList.Add(go);
                    }
                }


            }


        }
        else
        {
            foreach (GameObject go in TranscripManager._instance.enemyList)
            {

                float dis = Vector3.Distance(go.transform.position, this.transform.position);
                //print(dis);
                if (dis < DisAround)
                {
                    arrayList.Add(go);
                }
            }


        }

        return arrayList;
    }



    void ShowEffectSelfToTaget()
    {
        string effectName="FirePhoenixMobile";
        PlayEffect pe;
        effectDict.TryGetValue(effectName, out pe);
         ArrayList arrayList = GetEnemyInAttackRang(AttackRang.forWard);
        foreach(GameObject go in arrayList)
        {
            PlayEffect bird =GameObject.Instantiate(pe) as PlayEffect;
            bird.transform.position = this.transform.position;
            bird.GetComponent<EffectSettings>().Target=go;
            
        }

      



    }



    void TakeDamage(int damage)
    {

        print(damage);

        if(this.hp<=0)return;
        this.hp-=damage;

        int rang =Random.Range(0,8);
        // print(rang);
            if(rang<3)
            {
                playani.SetTrigger("TakeDamage");
               
            }
            else{
                playani.Play("idle");
            }


            hudtext.Add("-"+ damage,Color.red,0.3f);
            hpbarSlider.value =(float)this.hp/hptotal;

          


    }

}
