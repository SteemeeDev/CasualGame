using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YOUDIED : MonoBehaviour
{
    TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elaped = 0;

        while (elaped < 5)
        {
            elaped += Time.deltaTime;
            float t = elaped / 5;
            yield return null;
            text.color = new Color(text.color.r, text.color.g, text.color.b, t);
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenu");
    }
}
