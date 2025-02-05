using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    public Animator animator;
    public override void Awake()
    {
        base.Awake();
        attackSpeed = 7;
    }
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("Attack");
        if (!battleManager.currentEnemy.defending) battleManager.currentEnemy.health -= 18;
        if (battleManager.buffIndex == 0)
        {
            battleManager.currentEnemy.health -= 40;
            battleManager.player.health -= 20;
        }

        if (battleManager.buffIndex == 2)
        {

            battleManager.currentEnemy.health -= 10 * Random.Range(0, 2);
        }
        battleManager.currentEnemy.healthBar.currentHealth = battleManager.currentEnemy.health;
        Debug.Log("Attackin'");
    }
}
