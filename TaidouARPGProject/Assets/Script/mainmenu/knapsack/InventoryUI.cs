using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public static InventoryUI _instance;
    public  List<InventoryItemUI> itemList = new List<InventoryItemUI>();
    private UIButton clearUpButton;
    private UILabel InventoryLabel;
  

    private int count = 0;

    //public InventoryItem it;

    void Awake()
    {
        _instance = this;
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
        clearUpButton = transform.Find("ButtonClearup").GetComponent<UIButton>();
        InventoryLabel = transform.Find("InventoryLabel").GetComponent<UILabel>();

        EventDelegate ed = new EventDelegate(this, "OnClearUp");
        clearUpButton.onClick.Add(ed);
        

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
        int temp = 0;



        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            if(it.IsDress==false)
            {
                itemList[temp].SetInventoryItem(it);
                temp++;
            }
            
          
        }
        count = temp;
        for (int i = temp; i < itemList.Count; i++)
        {
            
            itemList[i].Clean();

        }

        InventoryLabel.text = count + "/32";
    }

    public void AddInventory(InventoryItem it)
    {
        foreach(InventoryItemUI itUI in itemList)
        {
            if(itUI.it==null)
            {
                itUI.SetInventoryItem(it);
                count++;
                break;
            }
        }
    }

    void OnClearUp()
    {
        //print("+++");
        UpdateShow();
    }


    public void UpdageCount()
    {
        count = 0;

        foreach (InventoryItemUI itUI in itemList) 
            //开始状态下 物品列表里为0；
        {
            if (itUI.it != null)
            {
                
                count++;

                
            }

        }
        InventoryLabel.text = count + "/32";

    }

}
