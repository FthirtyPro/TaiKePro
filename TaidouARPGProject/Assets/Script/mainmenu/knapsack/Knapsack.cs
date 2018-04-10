using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {

    // Use this for initialization

    private EquipPopup equipPopup;
    private InventoryPopup _inventoryPopup;
    private InventoryItemUI itUI;

    private void Awake()
    {
        equipPopup =transform.Find("EquipPopup").GetComponent<EquipPopup>();
        _inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();
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


    }
}
