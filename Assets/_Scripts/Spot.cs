using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DoozyUI;

public class Spot : MonoBehaviour, IPointerClickHandler
{
    public static GameObject parent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlantCheck())
        {
            PlantingManager.PickPlant(this.gameObject);
        }
        else
        {
            parent = this.gameObject;
            print("Spot empty");
            UIManager.ShowUiElement("PlantPicker", "UI");
        }
    }

    bool PlantCheck()
    {
        //if the spot has a child then there is already a plant present.
        bool planted;
        if (this.gameObject.transform.childCount > 0)
        {
            planted = true;
        }
        else
        {
            planted = false;
        }
        return planted;
    }
}
