using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 装备栏上面的图标显示
/// </summary>

public class KnapsackRoleEquip:MonoBehaviour  {

 private UISprite _sprite;
 private InventoryItem it;


void Awake()
{
        _sprite = this.GetComponent<UISprite>();
}

 private UISprite Sprite{
     get{
         if(_sprite ==null)
         { _sprite =this.GetComponent<UISprite>();}
          return _sprite;
     }
   
 
 }

    public void SetId(int id)
{
    Inventory _inventory = null;
    bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out _inventory);
    if(isExit)
    {
            
            Sprite.spriteName = _inventory.Icon;
    }
}

    public void SetInventoryItem(InventoryItem it)
    {
        if (it == null)
            return;
        this.it = it;
        Sprite.spriteName = it.Inventory.Icon;

    }

    public void Clean()
    {
        it = null;
        Sprite.spriteName = "bg_道具";
    }

    public void OnPress(bool isPress)//显示装备属性面板
    {
        if(isPress&&it!=null)
        {
            object[] objectArray = new object[3];
            objectArray[0] = it;
            objectArray[1] = false;
            objectArray[2] = this;

            transform.parent.parent.SendMessage("OnEquipClick", objectArray);


        }
    }



  

}
