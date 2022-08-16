using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IControllable {
    public GameObject blackBase;
    public GameObject whiteBase;

    public Sprite faceDown;

    public GameObject attackPoint;
    public GameObject tacticPoint;

    private IControllable _controllableObject;

    protected short HP = 1;
    protected short maxHP;
    protected CoinType unitType;

    public void printList(List<Vector2> list, string defaultText = "") {
        string res = defaultText;
        foreach (var el in list)
            res += el.ToString() + " ";
        Debug.Log(res);
    }
    
    public void printList(List<GameObject> list, string defaultText = "") {
        string res = defaultText;
        foreach (var el in list)
            res += el.ToString() + " ";
        Debug.Log(res);
    }
    
    public void printList(List<CoinType> list, string defaultText = "") {
        string res = defaultText;
        foreach (var el in list)
            res += el.ToString() + " ";
        Debug.Log(res);
    }

    private Vector2 Vector3ToVector2(Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }

    private List<Vector2> GOListToV2List(List<GameObject> list) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in list) {
            positionsList.Add(unit.transform.position);
        }
        return positionsList;
    }

    private GameObject FindGOWithPosition(List<GameObject> list, Vector2 position) {
        foreach (var el in list) {
            if (Vector3ToVector2(el.transform.position) == position)
                return el;
        }
        return null;
    }
    private Boolean ContainsV2InGOList(List<GameObject> list, Vector2 position) {
        if (list.Count == 0) return false;
        foreach (var el in list)
            if (Vector3ToVector2(el.transform.position) == position)
                return true;
        return false;
    }

    public Boolean listContains(List<Vector2> list, Vector2 position) {
        foreach (Vector2 pos in list)
            if (position == pos) return true;
        return false;
    }
    
    // Возвращает GameObject массив со всеми юнитами
    public List<GameObject> GetAllUnits() {
        List<GameObject> unitsList = new List<GameObject>();
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.BLACK_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.WHITE_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        return unitsList;
    }
    
    // Возвращает массив с позициями юнитов
    public List<Vector2> GetUnitsPosition() {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in GetAllUnits()) {
            positionsList.Add(unit.transform.position);
        }
        return positionsList;
    }
    // Возвращает массив с позициями команды
    public List<Vector2> GetTeamPosition(string team) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in GetAllUnits())
            if (unit.transform.parent.tag == team)
                positionsList.Add(unit.transform.position);
        return positionsList;
    }

    public GameObject GetUnit(Vector2 position) {
        foreach (var unit in GetAllUnits())
            if (Vector3ToVector2(unit.transform.position) == position)
                return unit;
        return null;
    }
    
    public bool UnitExist(CoinType type) {
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

    // Возвращает команду противника
    public string GetEnemyTeamName() {
        if (transform.parent.tag == Constants.WHITE) return Constants.BLACK;
        return Constants.WHITE;
    }

    // Возвращает список векторов смещённых на векторы из list
    public List<Vector2> GetMovedVectorList(List<Vector2> list, Vector2 vector) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (Vector2 pos in list) {
            Vector2 vec = new Vector2(pos.x + vector.x, pos.y + vector.y);
            foreach (var hexPos in Main.board)
                if (hexPos == vec)
                    positionsList.Add(vec);
        }
        return positionsList;
    }

    // Возвращает массив с позициями соседних противников
    private List<Vector2> GetNearEnemyPositions() {
        List<Vector2> positionsList = new List<Vector2>();
        
        foreach (Vector2 position in GetTeamPosition(GetEnemyTeamName())) 
            if (listContains(GetMovedVectorList(Constants.Circle1R, transform.position), position))
                positionsList.Add(position);
        return positionsList;
    }

    private List<GameObject> GetEnemyBases() {
        if (transform.parent.tag == Constants.BLACK)
            return Main.whiteControledBases;
        return Main.blackControledBases;
    }
    
    private List<GameObject> GetTeamBases() {
        if (transform.parent.tag == Constants.BLACK)
            return Main.blackControledBases;
        return Main.whiteControledBases;
    }
    
    private List<Vector2> GetTeamBasesPositions() {
        if (transform.parent.tag == Constants.BLACK)
            return GOListToV2List(Main.blackControledBases);
        return GOListToV2List(Main.whiteControledBases);
    }

    private CoinType GetUnitType(Vector2 position) {
        List<GameObject> units = GetAllUnits();
        foreach (GameObject unit in units)
            if (Vector3ToVector2(unit.transform.position) == position) {
                return unit.GetComponent<Unit>().unitType;
            }
        return CoinType.NULL;
    }

    private void IncreaseTeamPoints() {
        if (transform.parent.tag == Constants.BLACK) 
            Main.numOfBlackControledBases += 1;
        else if (transform.parent.tag == Constants.WHITE)
            Main.numOfWhiteControledBases += 1;
    }
    
    private void DecreaseEnemyPoints() {
        if (transform.parent.tag == Constants.BLACK) 
            Main.numOfWhiteControledBases -= 1;
        else if (transform.parent.tag == Constants.WHITE)
            Main.numOfBlackControledBases -= 1;
    }
    
    private void CreateBase() {
        GameObject _base;
        if (transform.parent.tag == Constants.BLACK) {
            Transform basesTransform = transform.parent.parent.parent.Find(Constants.BASES).Find(Constants.BLACK_BASES);
            _base = Instantiate(blackBase, transform.position, Quaternion.identity, basesTransform);
            Main.blackControledBases.Add(_base);
        }
        else if (transform.parent.tag == Constants.WHITE) {
            Transform basesTransform = transform.parent.parent.parent.Find(Constants.BASES).Find(Constants.WHITE_BASES);
            _base = Instantiate(whiteBase, transform.position, Quaternion.identity, basesTransform);
            Main.whiteControledBases.Add(_base);
        }
    }

    public void CreatePoint(GameObject point, Vector2 position, Transform parent) {
        GameObject _point = Instantiate(point, position, Quaternion.identity, parent);
        SpriteRenderer sprite = _point.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = Constants.POINT_ORDER_IN_LAYER;
    }

    private Vector2 GetMovedBiasVector2(Vector2 vector) {
        return new Vector2(vector.x + Constants.BOLSTER_BIAS.x * HP, vector.y + Constants.BOLSTER_BIAS.y * HP);
    }
    
    public void DestroyPoints() {
        try {Destroy(transform.Find(Constants.POINTS).gameObject);}
        catch (NullReferenceException) {}
    }
    
    public virtual void LoseHP() {
        HP--;
        Main.NumOfUnitsInBox[GetUnitType()]++;
        checkDeath();
    }

    private void checkDeath() {
        if (HP == 0) Death();
        else DestroyLastBolster();
    }

    private void Death() {
        Destroy(gameObject);
    }

    // Перемещение на выбранную точку
    public virtual void Move() {
        transform.position = MovePoints.movePosition;
    }
    
    // Захват выбранной базы
    public void Control() {
        List<GameObject> enemyBases = GetEnemyBases();
        if (ContainsV2InGOList(enemyBases, ControlPoints.controlPosition)) {
            GameObject enemyBase = FindGOWithPosition(enemyBases, ControlPoints.controlPosition);
            if (transform.parent.tag == Constants.BLACK)
                Main.whiteControledBases.Remove(enemyBase);
            else Main.blackControledBases.Remove(enemyBase);
            Destroy(enemyBase);
            DecreaseEnemyPoints();
        }
        if (!ContainsV2InGOList(GetTeamBases(), ControlPoints.controlPosition)) {
            CreateBase();
            IncreaseTeamPoints();
        }
    }
    
    public void Attack() {
        GameObject enemy = GetUnit(AttackPoints.attackPosition);
        _controllableObject = enemy.GetComponent<IControllable>();
        CoinType enemyType = enemy.GetComponent<Unit>().unitType;
        if (enemyType == CoinType.PIKEMAN)
            LoseHP();
        _controllableObject.LoseHP();
    }

    public virtual void Tactic(bool destroyHandCoin = true, bool destroyDeployPoint = true, bool destroyPoints = true, bool changeActiveTeam = true) {
        if (destroyHandCoin) DestroyHandCoin();
        if (destroyDeployPoint) DestroyDeployPoint();
        if (destroyPoints) DestroyPoints();
        if (changeActiveTeam) ChangeActiveTeam();
    }
    
    public void Bolster() {
        Transform bolster;
        if (transform.Find(Constants.BOLSTERS) == null) {
            GameObject bolsterGO = new GameObject(Constants.BOLSTERS);
            bolsterGO.transform.position = new Vector3(0, 0, 0);
            bolsterGO.transform.rotation = Quaternion.identity;
            bolsterGO.transform.parent = transform;
            bolsterGO.name = Constants.BOLSTERS;
            bolsterGO.transform.localScale = Constants.LOCAL_SCALE;
            bolsterGO.tag = Constants.BOLSTERS;
            bolster = bolsterGO.transform;
        }
        else
            bolster = transform.Find(Constants.BOLSTERS);

        GameObject unit = Instantiate(gameObject, GetMovedBiasVector2(transform.position), Quaternion.identity, bolster);
        _controllableObject = unit.GetComponent<IControllable>();
        SpriteRenderer sprite = unit.GetComponent<SpriteRenderer>();
        Destroy(unit.GetComponent<CircleCollider2D>());
        unit.transform.localScale = Constants.LOCAL_SCALE;
        unit.tag = Constants.UNTAGGED;
        sprite.sortingOrder = Constants.START_BOLSTER_ORDER_IN_LAYER + HP;
        HP++;
        Destroy(unit.transform.Find(Constants.BOLSTERS).gameObject);
        Destroy(unit.transform.Find(Constants.POINTS).gameObject);
    }

    // Создаёт точки на позициях, куда можно атаковать
    public virtual void CreateAttackPoints() {
        foreach (var position in GetNearEnemyPositions()) {
            if (GetUnitType(position) == CoinType.BISHOP && HP > Constants.MAX_HP_TO_ATTACK_BISHOP) continue;
            if (GetUnitType(position) == CoinType.KNIGHT && HP < Constants.MIN_HP_TO_ATTACK_KNIGHT) continue;
            CreatePoint(attackPoint, position, transform.Find(Constants.POINTS));
        }
    }

    // Создаёт точки на позициях, куда можно применить тактику
    public virtual void CreateTacticPoints() {}

    public void DestroyLastBolster() {
        Transform bolsters = transform.Find(Constants.BOLSTERS);
        GameObject lastChild = bolsters.GetChild(bolsters.childCount - 1).gameObject;
        Destroy(lastChild);
    }
    
    public void DestroyDeployPoint() {
        Transform deployTransform;
        if (Main.activeTeam == Constants.BLACK)
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.DEPLOY_POINTS_ZONE)[0].transform.Find(Constants.BLACK_DEPLOY_POINTS);
        else deployTransform = GameObject.FindGameObjectsWithTag(Constants.DEPLOY_POINTS_ZONE)[0].transform.Find(Constants.WHITE_DEPLOY_POINTS);
        foreach (Transform point in deployTransform) {
            Destroy(point.gameObject);
        }
    }
    public void ChangeActiveTeam() {
        if (Main.activeTeam == Constants.BLACK)
            Main.activeTeam = Constants.WHITE;
        else Main.activeTeam = Constants.BLACK;
    }

    public void HideHelpCoins() {
        if (Main.activeTeam == Constants.BLACK) {
            Main.blackHelpCoinFaceUp.gameObject.SetActive(false);
            Main.blackHelpCoinFaceDown.gameObject.SetActive(false);
        }
        else {
            Main.whiteHelpCoinFaceUp.gameObject.SetActive(false);
            Main.whiteHelpCoinFaceDown.gameObject.SetActive(false);
        }
    }
    
    public void DestroyHandCoin() {
        RemoveHandCoinFromList();
        if (ActivateUnit.unitForCoins != null) {
            if (Main.activeTeam == Constants.BLACK)
                Main.blackDiscard.Add(ActivateUnit.unitForCoins.GetComponent<Unit>().GetUnitType());
            else Main.whiteDiscard.Add(ActivateUnit.unitForCoins.GetComponent<Unit>().GetUnitType());
            CreateDiscardCoin(ActivateUnit.unitForCoins.gameObject);
            Destroy(ActivateUnit.unitForCoins.gameObject);
        }
    }

    public void CreateDiscardCoin(GameObject coin) {
        Transform parent;
        int numOfChild;
        Vector2 position;
        Transform discardZone = GameObject.FindGameObjectsWithTag(Constants.DISCARD_ZONE)[0].transform;
        if (Main.activeTeam == Constants.BLACK)
            parent = discardZone.Find(Constants.BLACK_DISCARD_ZONE);
        else parent = discardZone.Find(Constants.WHITE_DISCARD_ZONE);
        numOfChild = parent.childCount;
        if (Main.activeTeam == Constants.BLACK) {
            if (numOfChild == 0)
                position = Constants.startBlackDiscardZone;
            else position = Constants.startBlackDiscardZone + Constants.changeBlackDiscardZone * numOfChild;

        }
        else {
            if (numOfChild == 0)
                position = Constants.startWhiteDiscardZone;
            else position = Constants.startWhiteDiscardZone + Constants.changeWhiteDiscardZone * numOfChild;
        }
        
        GameObject _coin = Instantiate(coin, position, Quaternion.identity, parent);
        _coin.GetComponent<SpriteRenderer>().sortingOrder = numOfChild + 1;
        if (!Main.faceUp)
            _coin.GetComponent<SpriteRenderer>().sprite = faceDown;
    }

    public void DestroyHandCoinNotDiscard() {
        RemoveHandCoinFromList();
        if (ActivateUnit.unitForCoins != null)
            Destroy(ActivateUnit.unitForCoins.gameObject);
    }

    private void RemoveHandCoinFromList() {
        if (Main.activeTeam == Constants.BLACK) {
            if (ActivateUnit.unitForCoins != null) {
                for (int i = 0; i < Main.blackHand.Count; i++) {
                    if (Main.blackHand[i] == ActivateUnit.unitForCoins.GetComponent<Unit>().GetUnitType()) {
                        Main.blackHand.RemoveAt(i);
                        return;
                    }
                }
            }
        }
        else {
            if (ActivateUnit.unitForCoins != null) {
                for (int i = 0; i < Main.whiteHand.Count; i++) {
                    if (Main.whiteHand[i] == ActivateUnit.unitForCoins.GetComponent<Unit>().GetUnitType()) {
                        Main.whiteHand.RemoveAt(i);
                        return;
                    }
                }
            }
        }
    }
    
    public void DestroyCoinFaceDownPoints() {
        if (Main.activeTeam == Constants.BLACK)
            foreach (Transform point in GameObject.FindGameObjectsWithTag(Constants.COIN_FACE_DOWN_POINTS_ZONE)[0].transform.Find(Constants.BLACK_COIN_FACE_DOWN_POINTS))
                Destroy(point.gameObject);
        else 
            foreach (Transform point in GameObject.FindGameObjectsWithTag(Constants.COIN_FACE_DOWN_POINTS_ZONE)[0].transform.Find(Constants.WHITE_COIN_FACE_DOWN_POINTS))
                Destroy(point.gameObject);
    }

    public short GetUnitHP() {
        return HP;
    }
    
    public short GetUnitMaxHP() {
        return maxHP;
    }
    
    public CoinType GetUnitType() {
        return unitType;
    }
}
