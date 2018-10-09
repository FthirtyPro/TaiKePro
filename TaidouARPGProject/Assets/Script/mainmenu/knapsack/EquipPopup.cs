using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPopup : MonoBehaviour {
    private InventoryItem it;
   private InventoryItemUI itUI;
    //private KnapsackRoleEquip roleEquip;
    private bool isLeft;

    private UISprite equipSprite;
    private UILabel nameLabel;
    private UILabel qualityLabel;
    private UILabel damageLabel;
    private UILabel hpLabel;
    private UILabel powerLabel;
    private UILabel desLabel;
    private UILabel levelLabel;
    private UILabel btnLabel;
    private UIButton closeButton;
    private UIButton equipButton;
    private UIButton upgradeButton;
    private KnapsackRoleEquip roleEquip;

    public PowerShow power;


    void Awake()
    {
        equipSprite = transform.Find("EquipBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        qualityLabel = transform.Find("QualityLabel/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageLabel/Label").GetComponent<UILabel>();
        hpLabel = transform.Find("HpLabel/Label").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel/Label").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel/Label").GetComponent<UILabel>();
        btnLabel = transform.Find("EquipButton/Label").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        equipButton = transform.Find("EquipButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        //equipePuton = transform.Find("EquipPopup/EquipButton/Label").GetComponent<UILabel>();


        EventDelegate ed1 = new EventDelegate(this, "OnClose");
       closeButton.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(this, "OnEquip");
        equipButton.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "OnUpgrade");
        upgradeButton.onClick.Add(ed3);
    }

    public void Show(InventoryItem it,InventoryItemUI itUI, KnapsackRoleEquip roleEquip, bool isLeft=true)
    { 
       gameObject.SetActive(true);
        this.it = it;
        this.itUI = itUI;
        this.isLeft = isLeft;
        this.roleEquip = roleEquip;
        Vector3 pos = transform.localPosition;
        //窗口是在左边还是右边开启
        if (isLeft)
        {
            transform.localPosition = new Vector3(-Mathf.Abs(pos.x), pos.y, pos.z);
            btnLabel.text = "装备";
        }
        else
        {
            transform.localPosition = new Vector3(Mathf.Abs(pos.x), pos.y, pos.z);
            btnLabel.text = "卸下";

        }

        equipSprite.spriteName = it.Inventory.Icon;
        nameLabel.text = it.Inventory.Name;
        qualityLabel.text = it.Inventory.Quality.ToString();
        damageLabel.text = it.Inventory.Damage.ToString();
        hpLabel.text = it.Inventory.Hp.ToString();
        powerLabel.text = it.Inventory.Power.ToString();
        desLabel.text = it.Inventory.Des;
        levelLabel.text = it.Inventory.StartLeve.ToString();
         


    }
    public void OnClose()
    {
        Close();
        transform.parent.SendMessage("DisableButton");
    }

    public void Close()
    {
        gameObject.SetActive(false);

        ClearObject();
    }
    public void OnEquip()
    {
        int startValue = PlayerInfo._instanc.GetOverallPower();
        if(isLeft)
        {
            itUI.Clean();
            PlayerInfo._instanc.DressOn(it); //这里进行穿戴
            ;

        }
        else
        {
            
            PlayerInfo._instanc.DressOff(it);
            roleEquip.Clean();
           
        }

        ClearObject();
        gameObject.SetActive(false);
        int endValue = PlayerInfo._instanc.GetOverallPower();
        power.ShowPowerChange(startValue, endValue);
        InventoryUI._instance.SendMessage("UpdageCount");

        transform.parent.SendMessage("DisableButton");



    }

    void ClearObject()
    {
        it = null;
        itUI = null;
    }


 



    public void OnUpgrade()
    {
        int coinNeed = (it.Level + 1) * it.Inventory.Price;
        bool sussce = PlayerInfo._instanc.GetCoin(coinNeed);
        if (sussce)
        {
            it.Level+= 1;
            levelLabel.text = it.Level.ToString();
            //print(it.Level);
            print(coinNeed);
            print(PlayerInfo._instanc.Coin);
           
           
        }
        else
        {
            MessageManger._instance.ShowMessage("金币不足,无法升级",0.3f);
        }
    }

}
