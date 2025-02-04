using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    [SerializeField] Animator animator;

    public override void Awake()
    {
        base.Awake();
        if (battleManager.buffIndex == 1) attackSpeed = 9;
    }
    public override void Attack()
    {
        base.Attack();

        if (!battleManager.player.defending) battleManager.player.health -= 15;
        animator.SetTrigger("Attack");

        battleManager.healthText.text = battleManager.player.health.ToString();
        battleManager.player.healthBar.currentHealth = battleManager.player.health;
    }
}
