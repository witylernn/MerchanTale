using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class ShopScene : MonoBehaviour
{
    CanvasGroup cg;

    private void Start()
    {
        cg = GetComponentInChildren<CanvasGroup>();
        DialogueLua.SetVariable("End", false);
    }

    private void FixedUpdate()
    {

        if (DialogueLua.GetVariable("End").AsBool)
        {
            cg.alpha -= .02f;
            if (cg.alpha == 0)
            {
                DestroyObject(this.gameObject);
            }
        }
        else
        {
            if (cg.alpha < 1)
            {
                cg.alpha += .02f;
            }
        }
    }
}
