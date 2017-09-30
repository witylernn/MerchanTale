using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DoozyUI;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI date, gold;
    public InventoryManager InventoryManager;
    public UIElement Pause;
    public GameObject row1, row2, row3;
    public Sprite item1, item2, item3;

    private void Start()
    {
        float value = InventoryManager.inventory[0].y;
        gold.text = value.ToString();

        InvUpdate();
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

    public void InvUpdate()
    {
        foreach(Vector2 item in InventoryManager.inventory)
        {
            if (!SpriteCheck(Mathf.RoundToInt(item.x)))
            {
                foreach(Transform child in row1.transform)
                {
                    if (child.GetComponent<Image>().sprite == null)
                    {
                        switch (Mathf.RoundToInt(item.x))
                        {
                            case 1:
                                child.GetComponent<Image>().sprite = item1;
                                break;

                            case 2:
                                child.GetComponent<Image>().sprite = item2;
                                break;

                            case 3:
                                child.GetComponent<Image>().sprite = item3;
                                break;
                        }
                        break;
                    }
                }
            }
        }
    }

    bool SpriteCheck(int item)
    {
        Sprite spriteToCheck = null;
        Image spot;
        switch (item)
        {
            
            case 1:
                spriteToCheck = item1;
                break;

            case 2:
                spriteToCheck = item2;
                break;

            case 3:
                spriteToCheck = item3;
                break;

        }

        foreach(Transform child in row1.transform)
        {
            spot = child.GetComponent<Image>();
            if(spot.sprite == spriteToCheck)
            {
                return true;
            }

        }
        print("test");
        return false;
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
