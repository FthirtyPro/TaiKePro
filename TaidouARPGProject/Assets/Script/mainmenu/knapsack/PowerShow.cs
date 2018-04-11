using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShow : MonoBehaviour {

    private int startValue = 0;
    private float endValue = 0;
    private bool isStart = false;
    public int Speed = 100;
    private UILabel numLabel;
    private TweenAlpha tween;

    private bool isUp = true;//数字是否增加；

    private void Awake()
    {
        numLabel = transform.Find("Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();

        gameObject.SetActive(false);
        EventDelegate ed = new EventDelegate(this, "OnTweenfinish");
        tween.onFinished.Add(ed);
    }


    private void Update()
    {
        if(isStart==true)
        {
            if(isUp)
            {
                startValue +=(int)( Speed * Time.deltaTime);
                if(startValue > endValue)
                {
                    startValue = (int)endValue;
                    isStart = false;
                    tween.PlayReverse();
                }
            }
            else
            {
                startValue -= (int)(Speed * Time.deltaTime);
                if (startValue < endValue)
                {
         
                    isStart = false;
                    startValue = (int)endValue;
                    tween.PlayReverse();
                }

            }

            numLabel.text = (int)startValue + "";
        }
    }



    public void ShowPowerChange(int StartValue,int endValue)//设置对外的接口
    {
        gameObject.SetActive(true);
        tween.PlayForward();
        this.startValue = StartValue;
        this.endValue = endValue;

        if(endValue>StartValue)
        {
            isUp = true;
        }
        else
        {
            isUp = false;

        }
        isStart = true;

    }



    public void OnTweenfinish()
    {
        if(isStart == false)
        {
            gameObject.SetActive(false);
        }
    }

}
