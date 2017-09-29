using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DoozyUI;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI date, gold;
    public InventoryManager InventoryManager;
    public UIElement Pause;

    private void Start()
    {
        float value = InventoryManager.inventory[0].y;
        gold.text = value.ToString();
    }

    public void DateChange(int month, int day)
    {
        date.text = month.ToString() + "/" + day.ToString();
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

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Pause.isVisible)
            {
                Pause.Hide(false);
            }
            else
            {
                Pause.Show(false);
            }
        }
    }
}
