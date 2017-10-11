using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Vector2> inventory;
    public UIUpdater UIUpdater;

    public void InventoryAdd(int amount, int item, bool add)
    {
        bool exists = false;

        switch (add)
        {
            case true:
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].x == item)
                    {
                        exists = true;
                        inventory[i] = new Vector2(inventory[i].x, inventory[i].y + amount);
                    }
                    else
                    {
                        print("Not!");
                    }
                }
                if (!exists)
                {
                    inventory.Add(new Vector2(item, amount));
                }
                if (item == 0)
                {
                    UIUpdater.GoldChange(amount, true);
                }
                break;

            case false:
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].x == item)
                    {
                        exists = true;
                        if (inventory[i].y - amount < 0)
                        {
                            print("poor like the devs!");
                            PlantingManager.poor = true;
                        }
                        else
                        {
                            inventory[i] = new Vector2(inventory[i].x, inventory[i].y - amount);
                            if (inventory[i].x == 0)
                            {
                            }
                        }
                    }
                    else
                    {
                        print("Not!");
                    }
                }
                if (item == 0)
                {
                    UIUpdater.GoldChange(amount, false);
                }
                break;
        }
    }

    public bool CheckPoorness(int amount)
    {
        bool poor = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].x == 0)
            {
                if (inventory[i].y - amount < 0)
                {
                    poor = true;
                }
                else
                {
                    poor = false;
                }
                break;
            }
        }
        return poor;
    }

    public int CheckItemAmount(int item)
    {
        int amount = 0;
        for (int i = 0; i <inventory.Count; i++)
        {
            if (inventory[i].x == item)
            {
                amount = Mathf.RoundToInt(inventory[i].y);
            }
        }
        return amount;
    }

    /*
     Item List:
     0 - Gold
     1 - flower1
     2 - flower2
     3 - flower3
     100 - spear tip
     101 - spear handle
     102 - spear(full)
     
     
     */
}
