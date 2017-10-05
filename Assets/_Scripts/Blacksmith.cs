using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Blacksmith : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    SpriteOutline SpriteOutline;
    ParticleSystem ps;
    ConversationTrigger ct;

    private void Start()
    {
        ct = GetComponent<ConversationTrigger>();
        SpriteOutline = GetComponent<SpriteOutline>();
        ps = GetComponentInChildren<ParticleSystem>();
        ct.conversation = "Blacksmith";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("Pulse");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        SpriteOutline.outlineSize = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ps.Play();
        ct.enabled = true;
        ct.enabled = false;
    }

    IEnumerator Pulse()
    {
        float timer = .15f;

        SpriteOutline.outlineSize = 1;
        yield return new WaitForSeconds(timer);

        SpriteOutline.outlineSize = 2;
        yield return new WaitForSeconds(timer);

        SpriteOutline.outlineSize = 3;
        yield return new WaitForSeconds(timer);

        SpriteOutline.outlineSize = 4;
        yield return new WaitForSeconds(timer);

        SpriteOutline.outlineSize = 3;
        yield return new WaitForSeconds(timer);

        SpriteOutline.outlineSize = 2;
        yield return new WaitForSeconds(timer);

        StartCoroutine(Pulse());
    }
}
