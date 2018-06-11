using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : MonoBehaviour {

private Renderer[] renderArray;
private NcCurveAnimation[]  nccurveArrey;

void  Update()
{
   if(Input.GetMouseButton(0))
   Show();
}

void Start()
{
    renderArray = this.GetComponentsInChildren<Renderer>();
    nccurveArrey = this.GetComponentsInChildren<NcCurveAnimation>();
}

public void Show()
{
    foreach(Renderer  render in renderArray)
    {
        render.enabled =true;
    }
    foreach(NcCurveAnimation  Ncc in nccurveArrey)
    {
        Ncc.ResetAnimation();
    }
}



}
