using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Blacksmith : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SpriteOutline SpriteOutline;
    public ParticleSystem ps;

    private void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("Pulse");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        SpriteOutline.outlineSize = 0;
        print("test");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ps.Play();
        DialogueManager.StartConversation("Blacksmith");
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
