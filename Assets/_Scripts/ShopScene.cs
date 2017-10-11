using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class ShopScene : MonoBehaviour
{
    public CanvasGroup cg, diag;
    AlertTrigger at;

    private void Start()
    {
        cg = GetComponentInChildren<CanvasGroup>();
        at = GetComponent<AlertTrigger>();
        DialogueLua.SetVariable("End", false);
    }

    private void FixedUpdate()
    {

        if (DialogueLua.GetVariable("End").AsBool)
        {
            cg.alpha -= .02f;
            if (cg.alpha < .2f)
            {
                //at.enabled = true;
            }
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
