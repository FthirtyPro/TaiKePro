using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public static InventoryUI _instance;
    public  List<InventoryItemUI> itemList = new List<InventoryItemUI>();
    //public InventoryItem it;

    void Awake()
    {
        _instance = this;
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
    }


    void OnInventoryChange()
    {
        UpdateShow();
    }

    void OnDestroy()
    {
        InventoryManager._instance.OnInventoryChange -= this.OnInventoryChange;
    }


    void UpdateShow()
    {

        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            itemList[i].SetInventoryItem(it);
          //  print(it.Inventory.Icon);
        }
        for (int i = InventoryManager._instance.inventoryItemList.Count; i < itemList.Count; i++)
        {
            //InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            itemList[i].Clean();

        }
    }

    public void AddInventory(InventoryItem it)
    {
        foreach(InventoryItemUI itUI in itemList)
        {
            if(itUI.it==null)
            {
                itUI.SetInventoryItem(it);
                break;
            }
        }
    }

}
