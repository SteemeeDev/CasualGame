using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButto : Butto
{
    public override void Click()
    {
        if (battleManager.timeSinceMove > battleManager.moveSpeed)
        {
            battleManager.timeSinceMove = 0;
            battleManager.player.health += 26;
        }
    }
}
