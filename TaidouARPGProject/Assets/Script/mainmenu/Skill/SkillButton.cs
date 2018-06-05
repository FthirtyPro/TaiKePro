using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {

    public PosType pos;
    private PlayerAnimationPlay playaniPlay;

    private void Awake()
    {
        playaniPlay = TranscripManager._instance.player.GetComponent<PlayerAnimationPlay>();
    }
    // Use this for initialization
    void OnPress(bool ispress)
    {
        playaniPlay.OnAttackButtonClick(ispress,pos);
    }
}
