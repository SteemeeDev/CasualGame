using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butto : MonoBehaviour
{
    public Vector3 startScale;
    public Vector3 startPos;
    void Start()
    {
        startScale = transform.localScale;
        startPos = transform.position;
    }


    public virtual void Click()
    {

    }

}
