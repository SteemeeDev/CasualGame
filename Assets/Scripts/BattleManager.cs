using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Enemy player;
    public Enemy currentEnemy;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            //Die
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentEnemy.Attack();
        }
    }
}
