using System.Collections.Generic;
using UnityEngine;

public class crossbowman : Unit {
    public crossbowman() {
        unitType = CoinType.CROSSBOWMAN;
        maxHP = Constants.MAX_CROSSBOWMAN_HP;
    }
    
    private IControllable _controllableObject;

    public override void CreateTacticPoints() {
        foreach (var position in GetTacticPointPosition()) {
            CreatePoint(tacticPoint, position, transform.Find(Constants.POINTS));
        }
    }
    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {
        GameObject enemy = GetUnit(TacticPoints.tacticPosition);
        _controllableObject = enemy.GetComponent<IControllable>();
        _controllableObject.LoseHP();
        base.Tactic();
    }

    private List<Vector2> GetTacticPointPosition() {
        List<Vector2> positionsList = new List<Vector2>();
        List<Vector2> Circle2R = GetMovedVectorList(Constants.Rays2R, transform.position);
        foreach (Vector2 position in Circle2R)
            if (listContains(GetTeamPosition(GetEnemyTeamName()), position))
                positionsList.Add(position);
        return positionsList;
    }
}
