using System.Collections.Generic;
using UnityEngine;

public class bannerman : Unit {
    public bannerman() {
        unitType = CoinType.BANNERMAN;
        maxHP = Constants.MAX_BANNERMAN_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
