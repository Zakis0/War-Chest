using System.Collections.Generic;
using UnityEngine;

public class lancer : Unit {
    public lancer() {
        unitType = CoinType.LANCER;
        maxHP = Constants.MAX_LANCER_HP;

    }
    public override void CreateTacticPoints() {}
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {}
}
