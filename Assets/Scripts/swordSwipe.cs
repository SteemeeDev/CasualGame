using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSwipe : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();

        animator.SetTrigger("Swing");
    }
}
