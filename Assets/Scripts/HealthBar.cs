using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 startSize;
    Vector3 startPos;
    float maxHealth = 100f;
    public float currentHealth = 100f;


    // Start is called before the first frame update
    void Start()
    {
        startSize = transform.localScale;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(startSize.x*(currentHealth / maxHealth), startSize.y, startSize.z);
        transform.position = new Vector3(startPos.x - ((startSize.x / 2) * (1-(currentHealth / maxHealth))), startPos.y,startPos.z);
    }
}