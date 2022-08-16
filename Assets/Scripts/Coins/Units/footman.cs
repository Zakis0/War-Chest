using System.Collections.Generic;
using UnityEngine;

public class footman : Unit {
    public footman() {
        unitType = CoinType.FOOTMAN;
        maxHP = Constants.MAX_FOOTMAN_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
