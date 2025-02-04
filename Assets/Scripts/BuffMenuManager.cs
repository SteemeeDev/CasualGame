using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMenuManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public Buff[] buffs;

    public Buff selectedBuff;
    public int selectedBuffIndex = 0;

    public GameObject[] icons;

    public void UpdateIcon()
    {
        foreach (var item in icons)
        {
            item.SetActive(false);
        }

        icons[selectedBuff.buffIndex].SetActive(true);  
    }
}
