using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public TextAsset skill;
    private ArrayList skillList = new ArrayList();

    public static SkillManager _instance;

    private void Awake()
    {
        _instance = this;
        readSkillText();
    }
    

    public void readSkillText()
    {
        string sr = skill.ToString();
        string[] str = sr.Split('\n');

        foreach(string arr in str)
        {
            string[] arrstr = arr.Split(',');

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
                    skillarr.SkillType =SkillType.Basic;
                    break;

                case "Skill":
                    skillarr.SkillType = SkillType.Skill;

                    break;

            }

            switch (arrstr[5])
            {
                case "Basic":
                    skillarr.PosType = PosType.Basic;
                    break;

                case "One":
                    skillarr.PosType = PosType.One;

                    break;

                case "Two":
                    skillarr.PosType = PosType.Two;

                    break;

                case "Three":
                    skillarr.PosType = PosType.Three;

                    break;

            }

            skillarr.ColdTime = int.Parse(arrstr[6]);
            skillarr.Damage = int.Parse(arrstr[7]);


        skillList.Add(skillarr);

        }
    }


    public Skill GetSkillbyPosition(PosType postype)
    {
        
        PlayerInfo info = PlayerInfo._instanc;

        foreach(Skill skill in skillList)
        {
            if(skill.PlayerType== info.PlayerType&& skill.PosType==postype)

             return skill;
            
        }
        return null;
    }


}
