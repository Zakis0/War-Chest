using System.Collections.Generic;
using UnityEngine;

public class ensign : Unit {
    public ensign() {
        unitType = CoinType.ENSIGN;
        maxHP = Constants.MAX_ENSIGN_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
