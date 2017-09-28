using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Vector2> inventory;

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
                        }
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
}
