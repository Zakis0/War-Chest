using System.Collections.Generic;
using UnityEngine;

public class lightCavalry : Unit {
    public lightCavalry() {
        unitType = CoinType.LIGHT_CAVALRY;
        maxHP = Constants.MAX_LIGHT_CAVALRY_HP;
    }

    public override void CreateTacticPoints() {
        foreach (var position in GetTacticPointPosition()) {
            CreatePoint(tacticPoint, position, transform.Find(Constants.POINTS));
        }
    }
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {
        transform.position = TacticPoints.tacticPosition;
        base.Tactic();
    }

    private List<Vector2> GetTacticPointPosition() {
        List<Vector2> positionsList = new List<Vector2>();
        List<Vector2> R1positions = new List<Vector2>() ;
        List<Vector2> R2positions = new List<Vector2>();
        foreach (var R1pos in GetMovedVectorList(Constants.Circle1R, transform.position)) {
            if (!listContains(GetUnitsPosition(), R1pos)) {
                R1positions.Add(R1pos);
            }
        }
        foreach (var R1pos in R1positions) {
            R2positions = GetMovedVectorList(Constants.Circle1R, R1pos);
            foreach (var R2pos in R2positions) {
                if (listContains(GetUnitsPosition(), R2pos)) continue;
                if (listContains(R1positions, R2pos)) continue;
                positionsList.Add(R2pos);
            }
        }
        return positionsList;
    }
}
