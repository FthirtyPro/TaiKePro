using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour {
    private UISprite _sprite;
    private UILabel _label;
    //定义一个属性
    public  InventoryItem it; // 

    //public delegate OnInventoryChange event();


    private UISprite Sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = transform.Find("Sprite").GetComponent<UISprite>();
            }
            return _sprite;
        }
    }

    private UILabel Label
    {
        get
        {
            if (_label == null)
            {
                _label = transform.Find("Label").GetComponent<UILabel>();
            }
            return _label;
        }
    }

    /// <summary>
    /// 物品栏显示icon图标
    /// </summary>
    /// <param name="it"></param>
    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Sprite.spriteName = it.Inventory.Icon;
        if(it.Count<=1)
        {
            Label.text = "";
        }
        else
        {
            Label.text = it.Count.ToString();

        }
    }

    public void Clean()
    {
        it = null;
        Sprite.spriteName = "";
        Label.text = "bg_道具";
    }

    public void OnPress(bool isPress)
    {
        if (isPress&&it!=null)
        {
            object[] objectArray = new object[3];
            objectArray[0] = it;
            objectArray[1] = true;
            objectArray[2] = this;

            transform.parent.parent.parent.SendMessage("OnEquipClick", objectArray);


        }
    }

    //icon数量减少
    public void ChangeCount(int count)
    {
        if(it.Count-count<=0)
        {
            Clean();
        }else if(it.Count-count==1)
        {
            Label.text = "";
        }
        else
        {
            Label.text = (it.Count - count).ToString();
        }
    }


    public void OnClose()
    {
        it = null;
        gameObject.SetActive(false);
    }
}
