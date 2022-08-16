using System.Collections.Generic;
using UnityEngine;

public class warWagon : Unit {
    public warWagon() {
        unitType = CoinType.WAR_WAGON;
        maxHP = Constants.MAX_WAR_WAGON_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
