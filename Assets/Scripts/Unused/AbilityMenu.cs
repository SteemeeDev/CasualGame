using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using System.Threading.Tasks;
using UnityEngine;
using Unity.VisualScripting;

public class MixingMenu : MonoBehaviour
{
    public GameObject GO1;

    public GameObject[] Buttons;

    public int selectedIndex;
    public int index;
    public float easingTime = 0.15f;
    Vector3 hoverSizeIncrease = new Vector3(0.5f, 0.5f, 0);

    public Buff[] buffs;

    



    // This may be the worst code i have ever written, i apologize to anyone reading - Tore

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
          //  Buttons[selectedIndex].GetComponent<Animator>().enabled = false;
            SmoothExit(easingTime, Buttons, index);
            index = (index - 1 + Buttons.Length) % Buttons.Length;
            if (Buttons[index] == null) index = (index - 1 + Buttons.Length) % Buttons.Length;
            // Debug.Log(Buttons[selectedIndex]);
            SmoothHover(easingTime, Buttons, index);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           // Buttons[selectedIndex].GetComponent<Animator>().enabled = false;
            SmoothExit(easingTime, Buttons, index);
            index = (index + 1 + Buttons.Length) % Buttons.Length;
            if (Buttons[index] == null) index = (index + 1 + Buttons.Length) % Buttons.Length;
            // Debug.Log(Buttons[selectedIndex]);
            SmoothHover(easingTime, Buttons, index);
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GO1 != null)
            {
                Buttons[selectedIndex] = GO1;
                StartCoroutine(GO1.GetComponent<SelectBuff>().MoveToStartPos(0.15f));
            }

            selectedIndex = index;
            Buttons[index].GetComponent<Butto>().Click();   

            SmoothHover(easingTime, Buttons, index);
           // targetCamPos.position = Vector3.Lerp(defaultCamPos.position, rightButtons[rightIndex].transform.position, followAmount);

        }

    }

    public async void SmoothHover(float smoothTime, GameObject[] _buttons, int index)
    {
        float elapsed = 0;
        float t;

        Vector3 startScale = Vector3.zero;
        try
        {
            startScale = _buttons[index].GetComponent<Butto>().startScale;

            //  Debug.Log("Scaling up object " + index);

            while (elapsed < smoothTime)
            {
                elapsed += Time.deltaTime;
                t = elapsed / smoothTime;
                // m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                _buttons[index].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                await Task.Yield();
            }
        }
        catch
        {
            //  Debug.Log("Object cant be scaled!");
            return;
        }

    }
    public async void SmoothExit(float smoothTime, GameObject[] _buttons, int index)
    {
        float elapsed = smoothTime;
        float t;
        Vector3 startScale = Vector3.zero;
        try
        {
            startScale = _buttons[index].GetComponent<Butto>().startScale;
            //  Debug.Log("Scaling down object " + index);

            while (elapsed > 0)
            {
                elapsed -= Time.deltaTime;
                t = elapsed / smoothTime;
                //m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                _buttons[index].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                await Task.Yield();
            }
        }

        catch
        {
            //  Debug.Log("Object cant be scaled!");
            return;
        }
    }
}
