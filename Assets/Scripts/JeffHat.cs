using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffHat : Enemy
{
    public override void Attack()
    {
        base.Attack();
        battleManager.player.health -= 100;
    }
}
