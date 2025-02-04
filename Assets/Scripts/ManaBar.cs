using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    Vector3 startSize;
    Vector3 startPos;
    float maxMana;
    [SerializeField] BattleManager battleManager;
    public float currentMana;


    // Start is called before the first frame update
    void Start()
    {
        startSize = transform.localScale;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        maxMana = battleManager.moveSpeed;
        currentMana = battleManager.moveSpeed * battleManager.timeSinceMove / battleManager.moveSpeed;

        currentMana = Mathf.Clamp(currentMana, 0, maxMana);    

        transform.localScale = new Vector3(startSize.x * (currentMana / maxMana), startSize.y, startSize.z);
        transform.position = new Vector3(startPos.x - ((startSize.x / 2) * (1 - (currentMana / maxMana))), startPos.y, startPos.z);
    }
}
