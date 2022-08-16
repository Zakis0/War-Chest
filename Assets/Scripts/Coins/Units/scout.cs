using System.Collections.Generic;
using UnityEngine;

public class scout : Unit {
    public scout() {
        unitType = CoinType.SCOUT;
        maxHP = Constants.MAX_SCOUT_HP;
    }
    
    private IControllable _controllableObject;

    public override void CreateTacticPoints() {
        if (UnitExist(unitType)) return;
        Transform deployTransform;
        if (Main.activeTeam == Constants.BLACK)
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.DEPLOY_POINTS_ZONE)[0].transform.
                Find(Constants.BLACK_DEPLOY_POINTS);
        else
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.DEPLOY_POINTS_ZONE)[0].transform.
                Find(Constants.WHITE_DEPLOY_POINTS);
        foreach (Vector2 teamPosition in GetTeamPosition(Main.activeTeam)) {
            foreach (Vector2 position in GetMovedVectorList(Constants.Circle1R, teamPosition)) {
                if (!listContains(GetUnitsPosition(), position))
                    CreatePoint(tacticPoint, position, deployTransform);
            }
        }
    }

    public override void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {
        Transform deployTransform;
        if (Main.activeTeam == Constants.BLACK)
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.
                Find(Constants.BLACK_UNITS_ZONE);
        else
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.
                Find(Constants.WHITE_UNITS_ZONE);
        GameObject unit = Instantiate(gameObject, TacticPoints.tacticPosition, Quaternion.identity, deployTransform);
        _controllableObject = unit.GetComponent<IControllable>();
        _controllableObject.DestroyHandCoinNotDiscard();
        base.Tactic(false, destroyPoints: false);
    }
}
