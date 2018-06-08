using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscripManager : MonoBehaviour {

    public static TranscripManager _instance;
    public GameObject player;
    //public GameObject[] monsterList;
    public List<GameObject> enemyList = new List<GameObject>();
    private void Awake()
    {
        _instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


}
