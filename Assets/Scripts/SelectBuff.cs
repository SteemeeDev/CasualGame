using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SelectBuff : Butto
{


    [SerializeField] Transform targetPos;
    [SerializeField] MixingMenu _MenuManager;
   

    public override void Click()
    {
        base.Click();
        MoveTotarget(0.3f);
    }

    async void MoveTotarget(float smoothTime)
    {
        float elapsed = 0;

        _MenuManager.GO1 = gameObject;
        _MenuManager.Buttons[_MenuManager.selectedIndex] = null;
        _MenuManager.index = (_MenuManager.index - 1 + _MenuManager.Buttons.Length) % _MenuManager.Buttons.Length;


        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;
            transform.position = Vector2.Lerp(startPos, targetPos.position, 1 - Mathf.Pow(1 - t, 4));
            transform.localScale = startScale;
            await Task.Yield();
        }
    }

    public IEnumerator MoveToStartPos(float smoothTime)
    {
        float elapsed = 0;

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;
            transform.position = Vector2.Lerp(targetPos.position, startPos, 1 - Mathf.Pow(1 - t, 4));
            transform.localScale = startScale;
            yield return null;
        }
    }
}
