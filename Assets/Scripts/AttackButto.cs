using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButto : Butto
{
    public override void Click()
    {
        if (battleManager.timeSinceMove > battleManager.moveSpeed)
        {
            battleManager.timeSinceMove = 0;
            battleManager.player.Attack();
            battleManager.player.Attack();
            battleManager.player.Attack();
        }
    }
}
