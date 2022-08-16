using System.Collections.Generic;
using UnityEngine;

public class herald : Unit {
    public herald() {
        unitType = CoinType.HERALD;
        maxHP = Constants.MAX_HERALD_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
