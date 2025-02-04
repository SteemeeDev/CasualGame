using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BattleManager battleManager;
    public float health = 100f;
    public float maxHealth = 100f;
    public HealthBar healthBar;
    public bool defending = false;
    public GameObject defendSprite;

    public float attackSpeed = 7;

    public virtual void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }
    public virtual IEnumerator Block()
    {
        defending = true;
        float _elapsed = 0;
        defendSprite.SetActive(true); 
        while (_elapsed < 3) 
        { 
            yield return null; 
            _elapsed += Time.deltaTime;
        }
        defendSprite.SetActive(false);
        defending = false;
    }

    public virtual void Attack()
    {
       
    }

    public virtual void Heal()
    {

    }
    private float elapsed = 0;
    private float timeToNextMove = 7;
    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth); 
        elapsed += Time.deltaTime;
        healthBar.currentHealth = health;
        if (elapsed > timeToNextMove)
        {
            elapsed = 0;
            timeToNextMove = Random.Range(attackSpeed, attackSpeed+3f);
            Attack();
        }
    }


}
