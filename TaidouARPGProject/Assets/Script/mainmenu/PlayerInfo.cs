﻿using UnityEngine;
using System.Collections;

public enum InfoType {
    Name,
    HeadPortrait,
    Level,
    Power,
    Exp,
    Diamond,
    Coin,
    Energy,
    Toughen,
    HP,
    Damage,
    Equip,
    All
}
public enum PlayerType {
    Warrior,
    FemaleAssassin
}

public class PlayerInfo : MonoBehaviour {

    public static PlayerInfo _instanc;


    #region property
    private string _name;
    private string _headPortrait;
    private int _level = 1;
    private int _power = 1;
    private int _exp = 0;
    private int _diamond ;
    private int _coin;
    private int _energy;
    private int _toughen;
    private int _hp;
    private int _damage;
    private PlayerType _playerType;
    //private int _helmID =0 ;
    //private int _clothID =0 ;
    //private int _weaponID =0 ;
    //private int _shoesID=0;
    //private int _necklaceID=0;
    //private int _braceletID=0;
    //private int _ringID=0;
    //private int _wingID=0;


    public InventoryItem helmInventoryItem;
    public InventoryItem clothInventoryItem;
    public InventoryItem weaponInventoryItem;
    public InventoryItem shoesInventoryItem;
    public InventoryItem necklaceInventoryItem;
    public InventoryItem braceletInventoryItem;
    public InventoryItem ringInventoryItem;
    public InventoryItem wingInventoryItem;
    #endregion
    public float energyTimer = 0;
    public float toughenTimer = 0;

    public delegate void OnPlayerInfoChangedEvent( InfoType type );
    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;

    #region get set methd
    public string Name {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }
    public string HeadPortrait {
        get {
            return _headPortrait;
        }
        set {
            _headPortrait = value;
        }
    }
    public int Level {
        get {
            return _level;
        }
        set {
            _level = value;
        }
    }
    public int Power {
        get {
            return _power;
        }
        set {
            _power = value;
        }
    }
    public int Exp {
        get {
            return _exp;
        }
        set {
            _exp = value;
        }
    }
    public int Diamond {
        get {
            return _diamond;
        }
        set {
            _diamond = value;
        }

    }
    public int Coin {
        get {
            return _coin;
        }
        set {
            _coin = value;
        }
    }
    public int Energy {
        get {
            return _energy;
        }
        set {
            _energy = value;
        }
    }
    public int Toughen {
        get {
            return _toughen;
        }
        set {
            _toughen = value;
        }
    }
    public int HP{
        get{
            return _hp;
        }
        set{
            _hp = value;
        }
    }
    public int Damage{
        get{return _damage;}
        set{_damage = value;}
    }
    public PlayerType PlayerType {
        get {
            return _playerType;
        }
        set {
            _playerType = value;
        }
    }
    //public int HelmID{
    //    get{return _helmID; }
    //    set{_helmID=value;}
    //}
    //public int ClothID{
    //    get{return _clothID;}
    //    set{_clothID=value;}
    //}
    //public int WeaponID{
    //    get{
    //        return _weaponID;
    //    }
    //    set{
    //        _weaponID = value;
    //    }
    //}
    //public int ShoesID{
    //    get{
    //        return _shoesID;
    //    }
    //    set{
    //        _shoesID = value;
    //    }
    //}
    //public int NecklaceID{
    //    get{return _necklaceID;}
    //    set{ _necklaceID=value; }
    //}
    //public int BraceletID{
    //    get{return _braceletID;}
    //    set{_braceletID=value;}
    //}
    //public int RingID{
    //    get{return _ringID;}
    //    set{_ringID=value;}
    //}
    //public int WingID{
    //    get{
    //        return _wingID;
    //    }
    //    set{
    //        _wingID=value;
    //    }
    //}

    #endregion
    
    #region unity event
    void Awake() {
        _instanc = this;
    }

    void Start() {
        Init();
    }

    void Update() {
        //实现体力和历练的自动增长
        if (this.Energy < 100) {
            energyTimer += Time.deltaTime;
            if (energyTimer > 60) {
                Energy += 1;
                energyTimer -= 60;
                OnPlayerInfoChanged(InfoType.Energy);
            }
        } else {
            this.energyTimer = 0;
        }
        if (this.Toughen < 50) {
            toughenTimer += Time.deltaTime;
            if (toughenTimer > 60) {
                Toughen += 1;
                toughenTimer -= 60;
                OnPlayerInfoChanged(InfoType.Toughen);
            }
        } else {
            toughenTimer = 0;
        }

    }
    #endregion

    void Init() {
        this.Coin = 9870;
        this.Diamond = 1234;
        this.Energy = 78;
        this.Exp = 123;
        this.HeadPortrait = "头像底板女性";
        this.Level = 12;
        this.Name="千颂伊";
        this.Toughen = 34;

   

        OnPlayerInfoChanged( InfoType.All );
    }
   


    public void DressOn(InventoryItem it)
    {
        it.IsDress = true;
        bool isDressed = false;
        InventoryItem inventoryItemDress = null;
        switch(it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                if(braceletInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = braceletInventoryItem;
                }
                braceletInventoryItem = it;
                break;
            case EquipType.Helm:
                if (helmInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = helmInventoryItem;
                }
                helmInventoryItem = it;
                break;
            case EquipType.Cloth:
                if (clothInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = clothInventoryItem;
                }
                clothInventoryItem = it;
                break;
            case EquipType.Necklace:
                if (necklaceInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = necklaceInventoryItem;
                }
                necklaceInventoryItem = it;
                break;
            case EquipType.Weapon:
                if (weaponInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = weaponInventoryItem;
                }
                break;
            case EquipType.Shoes:
                if (shoesInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = shoesInventoryItem;
                }
                shoesInventoryItem = it;
                break;
            case EquipType.Ring:
                if (ringInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = ringInventoryItem;
                }
                ringInventoryItem = it;
                break;

            case EquipType.Wing:
                if (wingInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDress = wingInventoryItem;
                }
                wingInventoryItem = it;
                break;


        }


        if(isDressed)
        {
            inventoryItemDress.IsDress = false;
           


            InventoryUI._instance.AddInventory(inventoryItemDress);
        }


        //=============
        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                if (braceletInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = braceletInventoryItem;
                    braceletInventoryItem = it;
                }
                break;
            case EquipType.Helm:
                if (helmInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = helmInventoryItem;
                    helmInventoryItem = it;
                }
                break;
            case EquipType.Cloth:
                if (clothInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = clothInventoryItem;
                    clothInventoryItem = it;
                }
                break;
            case EquipType.Necklace:
                if (necklaceInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = necklaceInventoryItem;
                    necklaceInventoryItem = it;
                }
                break;
            case EquipType.Weapon:
                if (weaponInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = weaponInventoryItem;
                    weaponInventoryItem = it;
                }
                break;
            case EquipType.Shoes:
                if (shoesInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = shoesInventoryItem;
                    shoesInventoryItem = it;
                }
                break;
            case EquipType.Ring:
                if (ringInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = ringInventoryItem;
                    ringInventoryItem = it;
                }
                break;

            case EquipType.Wing:
                if (wingInventoryItem == null)
                {
                    isDressed = true;
                    inventoryItemDress = wingInventoryItem;
                    wingInventoryItem = it;
                }
                break;


        }


        OnPlayerInfoChanged(InfoType.Equip);


    }

    public bool GetCoin(int count)
    {
        if (Coin >= count)
        {
            
            Coin -= count;
            OnPlayerInfoChanged(InfoType.Coin);
            return true;
        }



        return false;
    }

    public void DressOff(InventoryItem it)
    {
        //it.IsDress = true;
        //bool isDressed = false;
        //InventoryItem inventoryItemDress = null;
        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                if (braceletInventoryItem != null)
                {
                    //isDressed = true;
                     braceletInventoryItem =null;
                }
                //braceletInventoryItem = it;
                break;
            case EquipType.Helm:
                if (helmInventoryItem != null)
                {
                   // isDressed = true;
                    helmInventoryItem =null;
                }
                //helmInventoryItem = it;
                break;
            case EquipType.Cloth:
                if (clothInventoryItem != null)
                {
                   // isDressed = true;
                    clothInventoryItem =null;
                }
                break;
            case EquipType.Necklace:
                if (necklaceInventoryItem != null)
                {
                
                     necklaceInventoryItem=null;
                }
                break;
            case EquipType.Weapon:
                if (weaponInventoryItem != null)
                {
                    weaponInventoryItem=null;
                }
                break;
            case EquipType.Shoes:
                if (shoesInventoryItem != null)
                {
                    shoesInventoryItem =null;
                }
               
                break;
            case EquipType.Ring:
                if (ringInventoryItem != null)
                {
                  ringInventoryItem =null;
                }
                break;

            case EquipType.Wing:
                if (wingInventoryItem != null)
                {
              wingInventoryItem=null;
                }
                break;


        }

        it.IsDress = true;
        InventoryUI._instance.AddInventory(it);
        OnPlayerInfoChanged(InfoType.Equip);

    }
}
