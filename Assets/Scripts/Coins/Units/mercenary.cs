using System.Collections.Generic;
using UnityEngine;

public class mercenary : Unit {
    public mercenary() {
        unitType = CoinType.MERCENARY;
        maxHP = Constants.MAX_MERCENARY_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
