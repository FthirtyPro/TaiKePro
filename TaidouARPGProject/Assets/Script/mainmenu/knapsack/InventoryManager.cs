using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager _instance;
    public TextAsset textAsset;
    public Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();//角色拥有的物品也存储成为字典



    //定义一个事件：当物品发生更改后。刷新

    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChange;
     void Awake()
    {
        _instance = this;
        ReadInventoryInfo();
    }

     void Start() {
        ReadServeInventoryItem();
    }
    /// <summary>
    /// 解读装备文本
    /// </summary>
    void ReadInventoryInfo()
    {
        string str = textAsset.ToString();
        string[] itemStrArray = str.Split('\n');
        foreach (string itemstr in itemStrArray)
        {
            string[] proArray = itemstr.Split('|');
            Inventory _inventory = new Inventory();
            _inventory.Id = int.Parse(proArray[0]);
            _inventory.Name = proArray[1];
            _inventory.Icon = proArray[2];
            switch (proArray[3])
            {
                case "Equip":
                    _inventory.Inventorytype = InventoryType.Euqip;
                    break;
                case "Drug":
                    _inventory.Inventorytype = InventoryType.Drug;
                    break;
                case "Box":
                    _inventory.Inventorytype = InventoryType.Box;
                    break;
            }
            if (_inventory.Inventorytype == InventoryType.Euqip)
            {
                switch (proArray[4])
                {
                    case "Helm":
                        _inventory.EquipType = EquipType.Helm;
                        break;
                    case "Bracelet":
                        _inventory.EquipType = EquipType.Bracelet;
                        break;
                    case "Wing":
                        _inventory.EquipType = EquipType.Wing;
                        break;
                    case "Ring":
                        _inventory.EquipType = EquipType.Ring;
                        break;
                    case "Cloth":
                        _inventory.EquipType = EquipType.Cloth;
                        break;
                    case "Weapon":
                        _inventory.EquipType = EquipType.Weapon;
                        break;
                    case "Necklace":
                        _inventory.EquipType = EquipType.Necklace;
                        break;
                    case "Shoes":
                        _inventory.EquipType = EquipType.Shoes;
                        break;
                }
                _inventory.Price = int.Parse(proArray[5]);

                if (_inventory.Inventorytype == InventoryType.Euqip)
                {
                    _inventory.StarLevel = int.Parse(proArray[6]);
                    _inventory.Quality = int.Parse(proArray[7]);
                    _inventory.Damage = int.Parse(proArray[8]);
                    _inventory.Hp = int.Parse(proArray[9]);
                    _inventory.Power = int.Parse(proArray[10]);
                }
            }

            if (_inventory.Inventorytype  == InventoryType.Drug) {
                _inventory.ApplyValue = int.Parse(proArray[12]);
            }
            
            _inventory.Des = proArray[13];

            inventoryDict.Add(_inventory.Id, _inventory);

                
        }
    }
   
    public void RemoveInventoryItem(InventoryItem it)
    {
        this.inventoryItemList.Remove(it);
    }
   
   
    void ReadServeInventoryItem()
    {
        for (int i = 0; i < 20; i++)
        {
            int id = Random.Range(1001, 1020);

            Inventory n = null;
            inventoryDict.TryGetValue(id, out n);
    
            if (n.Inventorytype == InventoryType.Euqip)//如果是武器类型，那么判断有几个，级别是多少，数量多少
            {
                
                InventoryItem it = new InventoryItem();
                it.Inventory = n;
                it.Level = Random.Range(1, 10);
                it.Count = 1;
                inventoryItemList.Add(it); //在武器的类型下加入角色拥有的物品字典中
            }
            else
            {

                //判断背包里面是否已经有药品，箱子。判断是否存在，假设物品为空。便利拾取的跟容器中的id。如果id想匹配，说明存在。
                InventoryItem it = null;
                bool isExit = false;
                foreach (InventoryItem temp in inventoryItemList)
                {
                    if (temp.Inventory.Id == id)
                    {
                        isExit = true;
                        it = temp;
                        break;
                    }
                }
                if (isExit)
                {

                    it.Count++;

                }
                else
                {
                    it = new InventoryItem();
                    it.Inventory = n;
                    it.Count = 1;
                    inventoryItemList.Add(it);

                }
            }
        }

   OnInventoryChange();

    }
}






//到这里角色的装备初始化已经完成了
