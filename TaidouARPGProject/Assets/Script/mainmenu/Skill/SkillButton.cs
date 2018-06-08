using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {

    public PosType pos;
    private PlayerAnimationPlay playaniPlay;
    private UISprite mask;
    public float coldTime=4;
    private float coldTrate=0;
    private UIButton btn;

    private void Start()
    {
        btn =this.GetComponent<UIButton>();
        playaniPlay = TranscripManager._instance.player.GetComponent<PlayerAnimationPlay>();
        if(transform.Find("Mask"))
        {
        mask = transform.Find("Mask").GetComponent<UISprite>();
      
            
        }
    }

    void Update()
    {
        if(mask==null)
        return;

        if(coldTrate>0)
        {
          
            coldTrate-=Time.deltaTime;
            mask.fillAmount=coldTrate/coldTime; 
            
        }else{
           // print("00555");
            
            mask.fillAmount =0;
           
            enable();
        }

       
    }
    // Use this for initialization
    void OnPress(bool ispress)
    {
        playaniPlay.OnAttackButtonClick(ispress,pos);
        if(ispress&&mask!=null)
        {
            coldTrate =coldTime;
            print("0XX");
            
            Disable();
        }
    }


    void Disable()
    {
       btn.isEnabled=false;
       btn.SetState(UIButtonColor.State.Normal,true);
        print("001");

    }
     void enable()
    {
        btn.isEnabled=true;
      // btn.SetState(UIButtonColor.State.Normal,true);
    }
}
