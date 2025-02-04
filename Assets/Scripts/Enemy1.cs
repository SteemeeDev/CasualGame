using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public override void Attack()
    {
        battleManager.player.health--;
       
        base.Attack();
    }
}
