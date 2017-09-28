using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI date, gold;
    public InventoryManager InventoryManager;

    private void Start()
    {
        float value = InventoryManager.inventory[0].y;
        gold.text = value.ToString();
    }

    public void DateChange()
    {

    }

    public void GoldChange(int increment, bool add)
    {
        int current;
        int.TryParse(gold.text, out current);
        print(current);
        int value;
        if (add)
        {
            value = current + increment;
            gold.text = value.ToString();
        }
        else
        {
            value = current - increment;
            gold.text = value.ToString();
        }
        print(value);
    }
}
