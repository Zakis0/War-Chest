using System.Collections.Generic;
using UnityEngine;

public class warriorPriest : Unit {
    public warriorPriest() {
        unitType = CoinType.WARRIOR_PRIEST;
        maxHP = Constants.MAX_WARRIOR_PRIEST_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
