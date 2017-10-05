using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Shop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    SpriteOutline SpriteOutline;
    ParticleSystem ps;

    private void Start()
    {
        SpriteOutline = GetComponent<SpriteOutline>();
        ps = GetComponentInChildren<ParticleSystem>();
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
        GameObject go = Instantiate(Resources.Load("Shop")) as GameObject;
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