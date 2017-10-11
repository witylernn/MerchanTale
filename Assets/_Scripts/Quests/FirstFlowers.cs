using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class FirstFlowers : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public bool hasTip, hasHandle, hasSpear; 
    // Update is called once per frame

    private void Start()
    {
        //DialogueManager.ShowAlert("Quest Accepted!" , 2);
    }
    void Update ()
    {
        //if (InventoryManager.CheckItemAmount(100) > 0)
        //{
        //    print("You have the spear tip");
        //    hasTip = true;
        //    DialogueLua.SetVariable("hasTip", true);
        //}

        //if (InventoryManager.CheckItemAmount(101) > 0)
        //{
        //    print("You have the spear handle");
        //    hasHandle = true;
        //    DialogueLua.SetVariable("hasHandle", true);
        //}

        if (DialogueLua.GetVariable("hasTip").AsBool)
        {
            if (!hasTip)
            {
                InventoryManager.InventoryAdd(1, 100, true);
                hasTip = true;
            }
        }
    }
}
