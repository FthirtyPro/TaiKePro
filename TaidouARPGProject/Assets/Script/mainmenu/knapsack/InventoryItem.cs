using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem  {
    
    private  Inventory inventory;
    private int count = 0;
    private int level = 1;
    private bool isDress = false;

    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public Inventory Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }

    public bool IsDress
    {
        get
        {
            return isDress;
        }

        set
        {
            isDress = value;
        }
    }
}
