using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButto : Butto
{
    public BattleManager battleManager;
    public override void Click()
    {
        base.Click();
        battleManager.player.Attack();
    }
}
