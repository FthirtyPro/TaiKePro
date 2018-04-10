using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour {
    private UILabel NameLabel;
    private UISprite sprite;
    private UILabel Des;
    private UILabel btnlable;
    private UIButton closeButton;

    public InventoryItem it;



    private void Awake()
    {
        NameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        sprite = transform.Find("Bg/Sprite/Sprite").GetComponent<UISprite>();
        Des = transform.Find("Bg/Label").GetComponent<UILabel>();
        btnlable = transform.Find("Bg/ButtonUseBatching/Label").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();


        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);

    }




    public void Show(InventoryItem it)
    {
        gameObject.SetActive(true);
        NameLabel.text = it.Inventory.Name;
        sprite.spriteName = it.Inventory.Icon;
        Des.text = it.Inventory.Des;
        btnlable.text  = "批量使用（" + it.Count + "）";

    }


    void OnClose()
    {
        it = null;
        gameObject.SetActive(false);

    }

    public void OnEnquip()
    {

    }
}
