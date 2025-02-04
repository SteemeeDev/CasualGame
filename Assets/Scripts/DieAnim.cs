using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnim : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    public void Awake()
    {
        battleManager = FindFirstObjectByType<BattleManager>();
        StartCoroutine(spawnIn());
    }

    IEnumerator spawnIn()
    {
        float elapsed = 0;
        while (elapsed < 2)
        {
            float t = elapsed / 2;
            elapsed += Time.deltaTime;

            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, t);

            yield return null;
        }
    }

    public void Die()
    {
        StartCoroutine(battleManager.spawnNewEnemy());
    }
}
