using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour {
    private UILabel NameLabel;
    private UISprite sprite;
    private UILabel Des;
    private UILabel btnlable;
    private UIButton closeButton;
    private UIButton buttonUse;
    private UIButton buttonBatching;

    private InventoryItemUI itUI;

    public InventoryItem it;



    private void Awake()
    {
        NameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        sprite = transform.Find("Bg/Sprite/Sprite").GetComponent<UISprite>();
        Des = transform.Find("Bg/Label").GetComponent<UILabel>();
        btnlable = transform.Find("Bg/ButtonUseBatching/Label").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        buttonUse = transform.Find("Bg/ButtonUse").GetComponent<UIButton>();
        buttonBatching = transform.Find("Bg/ButtonUseBatching").GetComponent<UIButton>();



        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(this, "OnBatch");
        buttonBatching.onClick.Add(ed2);

        EventDelegate ed3 = new EventDelegate(this, "OnUse");
        buttonUse.onClick.Add(ed3);




    }




    public void Show(InventoryItem it,InventoryItemUI itUI)
    {
        gameObject.SetActive(true);

        this.it = it;
        this.itUI = itUI;
       
        NameLabel.text = it.Inventory.Name;
        sprite.spriteName = it.Inventory.Icon;
        Des.text = it.Inventory.Des;
        btnlable.text  = "批量使用（" + it.Count + "）";

    }


    void OnClose()
    {
        Close();


        transform.parent.SendMessage("DisableButton");


    }

    public void Close()
    {
        Clear();

        gameObject.SetActive(false);
    }

    public void OnBatch()
    {
        itUI.ChangeCount(it.Count);//处理icont的数量
        PlayerInfo._instanc.InventoryUse(it, it.Count);
        OnClose();


        //print("+++++");
    }

    public void OnUse()
    {
        itUI.ChangeCount(1);
        PlayerInfo._instanc.InventoryUse(it, 1);
        OnClose();

    }


    public void Clear()
    {
        this.it = null;
        this.itUI = null;
    }
}
