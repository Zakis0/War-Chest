using System.Collections.Generic;
using UnityEngine;

public class marshal : Unit {
    public marshal() {
        unitType = CoinType.MARSHAL;
        maxHP = Constants.MAX_MARSHAL_HP;
    }

    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
