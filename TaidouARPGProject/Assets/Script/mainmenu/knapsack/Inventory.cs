using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InventoryType
{
    Euqip,
    Drug,
    Box
}

public enum EquipType
{
    Helm,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing
}


public class Inventory
{

    private int _id;
    private string _name;
    private string _icon;
    public InventoryType _inventorytype; // 类型有装备跟药品；
    private EquipType equipType;
   // private int _leve = 1;
    //private int _count = 0;
    private int _price = 0;
    private int _startLeve = 1;
    private int _quality = 1;
    private int _hp = 0;
    private int _damage = 0;
    private int _power = 0;

    private InfoType _infoType;
    private int _applyValue;
    private string des;
    private int _starLevel;
    

    public int StarLevel
    {
        get{
            return _starLevel;
        }
        set{
            _starLevel =value;
        }
    }



    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string Icon
    {
        get
        {
            return _icon;
        }

        set
        {
            _icon = value;
        }
    }

    public InventoryType Inventorytype
    {
        get
        {
            return _inventorytype;
        }

        set
        {
            _inventorytype = value;
        }
    }

    public EquipType EquipType
    {
        get
        {
            return equipType;
        }

        set
        {
            equipType = value;
        }
    }

 

   

    public int Price
    {
        get
        {
            return _price;
        }

        set
        {
            _price = value;
        }
    }

    public int StartLeve
    {
        get
        {
            return _startLeve;
        }

        set
        {
            _startLeve = value;
        }
    }

    public int Quality
    {
        get
        {
            return _quality;
        }

        set
        {
            _quality = value;
        }
    }

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }

    public int Power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = value;
        }
    }

    public InfoType InfoType
    {
        get
        {
            return _infoType;
        }

        set
        {
            _infoType = value;
        }
    }

    public int ApplyValue
    {
        get
        {
            return _applyValue;
        }

        set
        {
            _applyValue = value;
        }
    }

    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }
}
