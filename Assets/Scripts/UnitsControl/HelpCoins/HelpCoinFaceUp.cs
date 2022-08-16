using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCoinFaceUp : MonoBehaviour {
    public GameObject attackPoint, bolsterPoint, controlPoint, deployPoint, movePoint, tacticPoint;

    private string team;
    public static Unit unit;
    
    private IControllable _controllableObject;

    private Transform pointsParent;
    private void OnMouseDown() {
        Main.faceUp = true;
        team = transform.parent.tag;
        unit = ActivateUnit.unitForCoins;
        unit.HideHelpCoins();

        if (!UnitExist(unit.GetUnitType())) {
            CreateDeployPoints();
        }
        else {
            if (GetUnitByType(unit.GetUnitType())[0].GetUnitType() != CoinType.FOOTMAN)
                unit = GetUnitByType(unit.GetUnitType())[0];
            _controllableObject = unit.GetComponent<IControllable>();
            pointsParent = CreatePointsParent();
            CreateMovePoints();
            CreateControlPoint();
            CreateAttackPoints();
            CreateBolsterPoint();
        }
        CreateTacticPoints();
    }

    private void CreateDeployPoints() {
        Transform parent;
        if (Main.activeTeam == Constants.BLACK)
            parent = GameObject.FindGameObjectsWithTag(Constants.DEPLOY_POINTS_ZONE)[0].transform.Find(Constants.BLACK_DEPLOY_POINTS);
        else parent = GameObject.FindGameObjectsWithTag(Constants.DEPLOY_POINTS_ZONE)[0].transform.Find(Constants.WHITE_DEPLOY_POINTS);
        foreach (Vector2 position in GetAllFreeTeamBases()) {
            CreatePoint(deployPoint, position, parent);
        }
    }
    
    private void CreateMovePoints() {
        foreach (Vector2 position in GetMovedVectorList(Constants.Circle1R, unit.transform.position)) {
            if (!listContains(GetUnitsPosition(), position))
                CreatePoint(movePoint, position, pointsParent);
        }
    }
    
    private void CreateControlPoint() {
        if (!listContains(Main.bases, unit.transform.position)) return;
        if (listContains(GetTeamBasesPositions(), unit.transform.position)) return;
        CreatePoint(controlPoint, unit.transform.position, pointsParent);
    }
    
    private void CreateAttackPoints() {
        unit.CreateAttackPoints();
    }

    private void CreateTacticPoints() {
        unit.CreateTacticPoints();
    }
    
    private void CreateBolsterPoint() {
        if (unit.GetUnitHP() < unit.GetUnitMaxHP())
            CreatePoint(bolsterPoint, unit.transform.position, pointsParent);
    }

    private void CreatePoint(GameObject point, Vector2 position, Transform parent) {
        GameObject _point = Instantiate(point, position, Quaternion.identity, parent);
        SpriteRenderer sprite = _point.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = Constants.POINT_ORDER_IN_LAYER;
    }

    private Transform CreatePointsParent() {
        GameObject points = new GameObject();
        points.transform.parent = unit.transform;
        points.name = Constants.POINTS;
        return points.transform;
    }

    private List<Unit> GetUnitByType(CoinType type) {
        List<Unit> unitList = new List<Unit>();
        foreach (GameObject unit in GetAllUnits())
            if (unit.GetComponent<Unit>().GetUnitType() == type)
                unitList.Add(unit.GetComponent<Unit>());
        return unitList;
    }

    private Boolean UnitExist(CoinType type) {
        if (type != CoinType.FOOTMAN) {
            foreach (GameObject unit in GetAllUnits())
                if (unit.GetComponent<Unit>().GetUnitType() == type)
                    return true;
        }
        else {
            short num = 0;
            foreach (GameObject unit in GetAllUnits())
                if (unit.GetComponent<Unit>().GetUnitType() == CoinType.FOOTMAN)
                    num++;
            if (num == 2) return true;
        }
        return false;
    }

    private List<Vector2> GetAllFreeTeamBases() {
        List<Vector2> baseList = new List<Vector2>();
        List<Vector2> tempList = new List<Vector2>();
        if (team == Constants.BLACK) tempList = Main.blackControledBasesPosition;
        else tempList = Main.whiteControledBasesPosition;
        foreach (Vector2 position in tempList) {
            if (!listContains(GOListToV2List(GetAllUnits()), position))
                baseList.Add(position);
        }
        return baseList;
    }
    
    private Boolean listContains(List<Vector2> positionList, Vector2 position) {
        if (positionList.Count == 0) return false;
        foreach (Vector2 pos in positionList)
            if (pos == position) return true;
        return false;
    }
    
    private List<Vector2> GOListToV2List(List<GameObject> list) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in list) {
            positionsList.Add(unit.transform.position);
        }
        return positionsList;
    }
    
    private List<GameObject> GetAllUnits() {
        List<GameObject> unitsList = new List<GameObject>();
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.BLACK_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.WHITE_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        return unitsList;
    }
    
    private List<Vector2> GetMovedVectorList(List<Vector2> list, Vector2 vector) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (Vector2 pos in list) {
            Vector2 vec = new Vector2(pos.x + vector.x, pos.y + vector.y);
            foreach (var hexPos in Main.board)
                if (hexPos == vec)
                    positionsList.Add(vec);
        }
        return positionsList;
    }
    
    private List<Vector2> GetUnitsPosition() {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in GetAllUnits()) {
            positionsList.Add(unit.transform.position);
        }
        return positionsList;
    }
    
    private List<Vector2> GetTeamBasesPositions() {
        if (transform.parent.tag == Constants.BLACK)
            return GOListToV2List(Main.blackControledBases);
        return GOListToV2List(Main.whiteControledBases);
    }
    
    private List<Vector2> GetNearEnemyPositions() {
        List<Vector2> positionsList = new List<Vector2>();
        
        foreach (Vector2 position in GetTeamPosition(GetEnemyTeamName())) 
            if (listContains(GetMovedVectorList(Constants.Circle1R, transform.position), position))
                positionsList.Add(position);
        return positionsList;
    }

    private List<Vector2> GetTeamPosition(string team) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in GetAllUnits())
            if (unit.transform.parent.tag == team)
                positionsList.Add(unit.transform.position);
        return positionsList;
    }
    
    private string GetEnemyTeamName() {
        if (transform.parent.tag == Constants.WHITE) return Constants.BLACK;
        return Constants.WHITE;
    }
    
    private Vector2 Vector3ToVector2(Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }
}
