using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BattleManager battleManager;
    public float health = 100f;
    public HealthBar healthBar;
    public virtual void Block()
    {

    }

    public virtual void Attack()
    {
        battleManager.healthText.text = battleManager.player.health.ToString();
    }

    public virtual void Heal()
    {

    }

    private void Update()
    {
        healthBar.currentHealth = health;
    }
}
