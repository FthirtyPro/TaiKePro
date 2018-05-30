using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{

    public enum PosType
    {
        Basic,
        One,
        Two,
        Three
    }

    public enum SkillType
    {
        Basic,
        Skill
    }


    private int id;
    private string name;
    private string icon;
    private int damage;
    private int cold;
    private int level = 1;
    private PlayerType playerType;
    private SkillType skillType;
    private PosType posType;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int Cold
    {
        get
        {
            return cold;
        }

        set
        {
            cold = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public PlayerType PlayerType
    {
        get
        {
            return playerType;
        }

        set
        {
            playerType = value;
        }
    }

    public SkillType Skilltype
    {
        get
        {
            return skillType;
        }

        set
        {
            skillType = value;
        }
    }

    public PosType Postype
    {
        get
        {
            return posType;
        }

        set
        {
            posType = value;
        }
    }
}

