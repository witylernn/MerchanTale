using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestManager : ScriptableObject
{

    public void QuestCheck()
    {
        GameObject go = GameObject.Find("Quest Manager");
        if (DialogueLua.GetQuestField("First Customer", "State").AsString == "active")
        {
            go.GetComponent<FirstFlowers>().enabled = true;
        }
        else
        {
            go.GetComponent<FirstFlowers>().enabled = false;
        }
    }
}
