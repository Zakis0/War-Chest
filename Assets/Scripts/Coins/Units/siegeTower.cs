using System.Collections.Generic;
using UnityEngine;

public class siegeTower : Unit {
    public siegeTower() {
        unitType = CoinType.SIEGE_TOWER;
        maxHP = Constants.MAX_SIEGE_TOWER_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
