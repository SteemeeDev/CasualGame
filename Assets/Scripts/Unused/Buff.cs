using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buff : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 startScale;
    public Vector3 startPos;
    public Color startCol;

    [SerializeField] BuffMenuManager menuManager;

    [SerializeField] public float easingTime = 0.15f;

    Image image;

    bool selected = false;

    public int buffIndex;

    void Start()
    {
        startScale = transform.localScale;
        startPos = transform.position;
        startCol = GetComponent<Image>().color;
        image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData pointerEventData) 
    {

        if (!selected)
        {
            menuManager.selectedBuff = this;
            menuManager.selectedBuffIndex = buffIndex;
            menuManager.UpdateIcon();
            foreach (var buff in menuManager.buffs)
            {
                buff.gameObject.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0.5f);
                buff.selected = false;
            }
            selected = true;
            image.color = Color.HSVToRGB(0, 0, 1);
        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Hovering!");
        if (!selected) StartCoroutine(SmoothHover(easingTime));
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Exiting!");
        if (!selected) StartCoroutine(SmoothExit(easingTime));
    }



    public IEnumerator SmoothHover(float smoothTime)
    {
        float elapsed = 0;
        float t;
        //  Debug.Log("Scaling up object " + index);

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            t = elapsed / smoothTime;
            // m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            image.color = Color.HSVToRGB(0,0, Mathf.Lerp(0.5f, 1, t));

            yield return null;
        }

    }
    public IEnumerator SmoothExit(float smoothTime)
    {
        float elapsed = smoothTime;
        float t;
        while (elapsed > 0)
        {
            elapsed -= Time.deltaTime;
            t = elapsed / smoothTime;
            //m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            image.color = Color.HSVToRGB(0, 0, Mathf.Lerp(0.5f, image.color.grayscale, t));

            yield return null;
        }
    }
}

