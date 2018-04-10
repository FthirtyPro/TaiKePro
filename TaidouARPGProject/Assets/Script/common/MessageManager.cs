using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {
    public static MessageManager _instance;
    private UILabel messageLabel;
    private TweenAlpha tween;
    private bool isSetActive = true;

  


    void Awake() {
        _instance = this;
        messageLabel = transform.Find("Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();
        EventDelegate ed = new EventDelegate(this, "OnTween");
        tween.onFinished.Add(ed);

        gameObject.SetActive(false);
    }

    IEnumerator Show(string msg, float time)
    {
        gameObject.SetActive(true);
        tween.PlayForward();
        messageLabel.text = msg;
        yield return new WaitForSeconds(time);
        isSetActive = false;
        tween.PlayReverse();
    }

    public void ShowMessage(string str,float time)
    {
        gameObject.SetActive(true);
        StartCoroutine(Show(str, time));
    }


 

    public  void OnTween()
    {
        if(isSetActive==false)
        {
            gameObject.SetActive(false);
            

        }

    }


}
