using System.Collections.Generic;
using UnityEngine;

public class berserker : Unit {
    public berserker() {
        unitType = CoinType.BERSERKER;
        maxHP = Constants.MAX_BERSERKER_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
