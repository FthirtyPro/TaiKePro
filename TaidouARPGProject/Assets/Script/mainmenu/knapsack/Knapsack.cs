using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {

    // Use this for initialization

    private EquipPopup equipPopup;
    private InventoryPopup _inventoryPopup;
    private InventoryItemUI itUI;
    public  UIButton ButtonSale;
    private UILabel priceLabel;

    //private InventoryItemUI itUI;


    private void Awake()
    {
        equipPopup =transform.Find("EquipPopup").GetComponent<EquipPopup>();
        _inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();
        ButtonSale = transform.Find("Inventory/ButtonSale").GetComponent<UIButton>();
        priceLabel = transform.Find("Inventory/PriceBg/Label").GetComponent<UILabel>();
        DisableButton();
        EventDelegate ed = new EventDelegate(this, "OnSale");
        ButtonSale.onClick.Add(ed);



    }

    public void OnEquipClick(object[]objectArray)
    {
        InventoryItem it = (InventoryItem)objectArray[0];
        bool isLeft = (bool)objectArray[1];
        

        if(it.Inventory.Inventorytype==InventoryType.Euqip)
        {
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if (isLeft == true)
            {
                itUI = objectArray[2] as InventoryItemUI;
            }
            else
            {
               roleEquip = objectArray[2] as KnapsackRoleEquip;
            }



  
            equipPopup.Show(it, itUI, roleEquip, isLeft);

        }
        else
        {
            InventoryItemUI itUI = objectArray[2] as InventoryItemUI;

            _inventoryPopup.Show(it, itUI);
        }

        //按钮出现，价格显示出来。
        if ((it.Inventory.Inventorytype == InventoryType.Euqip && isLeft == true || it.Inventory.Inventorytype != InventoryType.Euqip))
            {

            this.itUI = objectArray[2] as InventoryItemUI;

            EnableButton();
            priceLabel.text = (this.itUI.it.Inventory.Price * this.itUI.it.Count).ToString();
             }


    }

    public void DisableButton()
    {
        ButtonSale.SetState(UIButtonColor.State.Disabled, true);
        Collider but=ButtonSale.GetComponent<Collider>();
        but.enabled = false;
        priceLabel.text = "";

    }

    public void EnableButton()
    {
        ButtonSale.SetState(UIButtonColor.State.Normal, true);
        Collider but = ButtonSale.GetComponent<Collider>();
        but.enabled = true;

    }


    public void OnSale()
    {
        int price = int.Parse(priceLabel.text);
        PlayerInfo._instanc.AddCoin(price);
        print(PlayerInfo._instanc.Coin);
        InventoryManager._instance.RemoveInventoryItem(itUI.it);
        itUI.Clean();
        equipPopup.Close();
        _inventoryPopup.Close();
        DisableButton();

    }
}
