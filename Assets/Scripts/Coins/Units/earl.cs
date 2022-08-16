using System.Collections.Generic;
using UnityEngine;

public class earl : Unit {
    public earl() {
        unitType = CoinType.EARL;
        maxHP = Constants.MAX_EARL_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
