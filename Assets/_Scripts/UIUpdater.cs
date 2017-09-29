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
        foreach(Transform child in row1.transform)
        {
            Image sp = child.GetComponent<Image>();

            if (sp.sprite == null)
            {
                foreach(Vector2 item in InventoryManager.inventory)
                {
                    int itemInt = Mathf.RoundToInt(item.x);
                    if (item.x != 0)
                    {
                        print(itemInt);
                        foreach(Transform child1 in row1.transform)
                        {
                            Image sp1 = child1.GetComponent<Image>();

                            switch (itemInt)
                            {
                                case 1:
                                    if (sp1.sprite == item1)
                                    {
                                        print("exists");
                                        return;
                                    }
                                    break;

                                case 2:
                                    if (sp1.sprite == item2)
                                    {
                                        print("exists");
                                        return;
                                    }
                                    break;
                            }
                        }
                        SpriteAssign(itemInt, sp);
                    }
                }
            }
        }
    }

    void SpriteAssign(int item, Image sp)
    {
        switch (item)
        {
            case 1:
                sp.sprite = item1;
                break;

            case 2:
                sp.sprite = item2;
                break;

            case 3:
                sp.sprite = item3;
                break;
        }
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
