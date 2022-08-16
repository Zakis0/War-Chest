using System.Collections.Generic;
using UnityEngine;

public class royalGuard : Unit {
    public royalGuard() {
        unitType = CoinType.ROYAL_GUARD;
        maxHP = Constants.MAX_ROYAL_GUARD_HP;
    }
    

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
