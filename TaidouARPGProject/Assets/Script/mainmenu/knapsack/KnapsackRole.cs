using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackRole : MonoBehaviour
{
    private KnapsackRoleEquip helmEquip;
    private KnapsackRoleEquip clothEquip;
    private KnapsackRoleEquip weaponEquip;
    private KnapsackRoleEquip shoesEquip;
    private KnapsackRoleEquip necklackEquip;
    private KnapsackRoleEquip braceletEquip;
    private KnapsackRoleEquip ringEquip;
    private KnapsackRoleEquip wingEquip;

    private UILabel hpLabel;
    private UILabel damageLabel;
    private UILabel expLabel;
    private UISlider expSlider;

    void Awake() {
        helmEquip = transform.Find("HelmSprite").GetComponent<KnapsackRoleEquip>();
        clothEquip = transform.Find("ClothSprite").GetComponent<KnapsackRoleEquip>();
        weaponEquip = transform.Find("WeaponSprite").GetComponent<KnapsackRoleEquip>();
        shoesEquip = transform.Find("ShoesSprite").GetComponent<KnapsackRoleEquip>();
        necklackEquip = transform.Find("NecklaceSprite").GetComponent<KnapsackRoleEquip>();
        braceletEquip = transform.Find("BraceletSprite").GetComponent<KnapsackRoleEquip>();
        ringEquip = transform.Find("RingSprite").GetComponent<KnapsackRoleEquip>();
        wingEquip = transform.Find("WingSprite").GetComponent<KnapsackRoleEquip>();

        hpLabel = transform.Find("HpBg/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageBg/Label").GetComponent<UILabel>();
        expLabel = transform.Find("ExpSlider/Label").GetComponent<UILabel>();
        expSlider = transform.Find("ExpSlider").GetComponent<UISlider>();
        PlayerInfo._instanc.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
     
    }

     void OnDestroy() {
        PlayerInfo._instanc.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }
    //注销事件
     void OnPlayerInfoChanged(InfoType type)
     //注册事件
     {
         if(/*type==InfoType.All||*/type ==InfoType.Equip)
         {
             UpdateShow();
         }

     }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instanc;
    

        helmEquip.SetInventoryItem(info.helmInventoryItem);
       clothEquip.SetInventoryItem(info.clothInventoryItem);
       weaponEquip.SetInventoryItem(info.weaponInventoryItem);
       shoesEquip.SetInventoryItem(info.shoesInventoryItem);
       necklackEquip.SetInventoryItem(info.necklaceInventoryItem);
       braceletEquip.SetInventoryItem(info.braceletInventoryItem);
      ringEquip.SetInventoryItem(info.ringInventoryItem);
       wingEquip.SetInventoryItem(info.wingInventoryItem);
       
    }

}
