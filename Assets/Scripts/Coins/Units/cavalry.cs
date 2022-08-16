using System.Collections.Generic;
using UnityEngine;

public class cavalry : Unit {
    public cavalry() {
        unitType = CoinType.CAVALRY;
        maxHP = Constants.MAX_CAVALRY_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
