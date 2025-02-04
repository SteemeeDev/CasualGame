using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    public override void Attack()
    {
        battleManager.currentEnemy.health -= 5;
        battleManager.currentEnemy.healthBar.currentHealth -= 5;
    }
}
