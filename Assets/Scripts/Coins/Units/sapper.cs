using System.Collections.Generic;
using UnityEngine;

public class sapper : Unit {
    public sapper() {
        unitType = CoinType.SAPPER;
        maxHP = Constants.MAX_SAPPER_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
