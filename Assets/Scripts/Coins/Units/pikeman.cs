using System.Collections.Generic;
using UnityEngine;

public class pikeman : Unit {
    public pikeman() {
        unitType = CoinType.PIKEMAN;
        maxHP = Constants.MAX_PIKEMAN_HP;
    }
}
