using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;
using UnityEngine.UI;

public class Butto : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 startScale;
    public Vector3 startPos;
    public Color startCol;

    [SerializeField] Vector3 hoverSizeIncrease = new Vector3(0.005f, 0.005f, 0);
    [SerializeField] public float easingTime = 0.15f;

    public BattleManager battleManager;
    void Start()
    {
        startScale = transform.localScale;
        startPos = transform.position;
        startCol = GetComponent<Image>().color;
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("HOVER");
        StartCoroutine(SmoothHover(easingTime));
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Exit");
        StartCoroutine(SmoothExit(easingTime));
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("CLICK");
        Click();
    }

    public virtual void Click()
    {

    }

    private void Update()
    {
        if (battleManager.timeSinceMove > battleManager.moveSpeed)
        {
            GetComponent<Image>().color = startCol;    
        }
        else
        {
            GetComponent<Image>().color = new Color(startCol.r, startCol.b, startCol.g, 0.5f);
        }
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

            transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

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

           transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            yield return null;
        }
    }

}
