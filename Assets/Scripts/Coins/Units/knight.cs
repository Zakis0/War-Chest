using System.Collections.Generic;
using UnityEngine;

public class knight : Unit {
    public knight() {
        unitType = CoinType.KNIGHT;
        maxHP = Constants.MAX_KNIGHT_HP;
    }
}
