using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public TextAsset skill;
    public static SkillManager _instance;

    private void Awake()
    {
        _instance = this;
        ///readSkillText();
    }
    private void Start()
    {
        readSkillText();
    }

    public void readSkillText()
    {
        string sr = skill.ToString();
        string[] str = sr.Split('\n');

        foreach(string arr in str)
        {
            string[] arrstr = arr.Split('|');

            Skill skillarr = new Skill();
            skillarr.Id = int.Parse(arrstr[0]);
            skillarr.Name = arrstr[1];
            skillarr.Icon = arrstr[2];
            switch(arrstr[3])
            {
                case "Warrior":
                    skillarr.PlayerType = PlayerType.Warrior;
                    break;

                case "FemaleAssassin":
                    skillarr.PlayerType = PlayerType.FemaleAssassin;
                    break;


            }
            switch (arrstr[4])
            {
                case "Basic":
                    skillarr.Skilltype =Skill.SkillType.Basic;
                    break;

                case "Skill":
                    skillarr.Skilltype = Skill.SkillType.Skill;

                    break;

            }

            switch (arrstr[5])
            {
                case "Basic":
                    skillarr.Postype = Skill.PosType.Basic;
                    break;

                case "One":
                    skillarr.Postype = Skill.PosType.One;

                    break;

                case "Two":
                    skillarr.Skilltype = Skill.SkillType.Skill;

                    break;

                case "Three":
                    skillarr.Skilltype = Skill.SkillType.Skill;

                    break;

            }

            skillarr.Cold = int.Parse(arrstr[6]);
            skillarr.Damage = int.Parse(arrstr[7]);




        }
    }


}
