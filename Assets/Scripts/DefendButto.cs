using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendButto : Butto
{
    public override void Click()
    {
        if (battleManager.timeSinceMove > battleManager.moveSpeed)
        {
            battleManager.timeSinceMove = 2.5f;
            StartCoroutine(battleManager.player.Block());
        }
    }
}
