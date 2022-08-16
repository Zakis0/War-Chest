using System.Collections.Generic;
using UnityEngine;

public class bishop : Unit {
    public bishop() {
        unitType = CoinType.BISHOP;
        maxHP = Constants.MAX_BISHOP_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
