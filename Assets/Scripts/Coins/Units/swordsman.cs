using System.Collections.Generic;
using UnityEngine;

public class swordsman : Unit {
    public swordsman() {
        unitType = CoinType.SWORDSMAN;
        maxHP = Constants.MAX_SWORDSMAN_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
