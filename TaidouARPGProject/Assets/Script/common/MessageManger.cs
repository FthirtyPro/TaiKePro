using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManger : MonoBehaviour {

    public static MessageManger _instance;
    private UILabel messageLabel;
    private TweenAlpha tween;
    private bool isSetAction = true;
     void Awake()
    {
        _instance = this;
        messageLabel = transform.Find("Sprite/Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();
        EventDelegate ed = new EventDelegate(this, "OnTweenFinished");
        tween.onFinished.Add(ed);
        gameObject.SetActive(false);
    }
   public void ShowMessage(string message ,float time=1)
    {
        gameObject.SetActive(true);

        StartCoroutine(Show(message,time));
    }

    //private void StartCoroutine(IEnumerable enumerable)
    //{
    //    throw new NotImplementedException();
    //}

    IEnumerator Show(string message, float time)
    {
        isSetAction = true;
        tween.PlayForward();
        messageLabel.text = message;

        yield return new WaitForSeconds(time);
        isSetAction = false;

        tween.PlayReverse();
    }


    public void OnTweenFinished()
    {

        if(isSetAction ==false)
        {
            gameObject.SetActive(false);
        }
    }
}
