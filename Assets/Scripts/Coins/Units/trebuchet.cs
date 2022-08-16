using System.Collections.Generic;
using UnityEngine;

public class trebuchet : Unit {
    public trebuchet() {
        unitType = CoinType.TREBUCHET;
        maxHP = Constants.MAX_TREBUCHET_HP;
    }
    
    private IControllable _controllableObject;

    public override void CreateAttackPoints() {}

    public override void CreateTacticPoints() {
        if (HP > 1)
            foreach (var position in GetTacticPointPosition())
                CreatePoint(tacticPoint, position, transform.Find(Constants.POINTS));
    }
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {
        GameObject enemy = GetUnit(TacticPoints.tacticPosition);
        _controllableObject = enemy.GetComponent<IControllable>();
        _controllableObject.LoseHP();
        base.Tactic();
    }

    private List<Vector2> GetTacticPointPosition() {
        List<Vector2> positionsList = new List<Vector2>();
        List<Vector2> Rays2R_AND_3R = GetMovedVectorList(Constants.Rays2R_AND_3R, transform.position);
        foreach (Vector2 position in Rays2R_AND_3R)
            if (listContains(GetTeamPosition(GetEnemyTeamName()), position))
                positionsList.Add(position);
        return positionsList;
    }
}
