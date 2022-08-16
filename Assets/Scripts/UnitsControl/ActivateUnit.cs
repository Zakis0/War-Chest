using System;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUnit : MonoBehaviour {
    
    public GameObject
        royalBlack,
        royalWhite,
        archer,
        bannerman,
        berserker,
        bishop,
        cavalry,
        crossbowman,
        earl,
        ensign,
        footman,
        herald,
        knight,
        lancer,
        lightCavalry,
        marshal,
        mercenary,
        pikeman,
        royalGuard,
        sapper,
        scout,
        siegeTower,
        swordsman,
        trebuchet,
        war_wagon,
        warrior_priest;

    public static GameObject lastActiveUnit;
    public static GameObject activeUnit;
    public static GameObject activatedUnitGO;
    public static Unit unitForCoins;
    public static GameObject unitToRecruit;

    private IControllable _controllableObject;
    private String team;
    private static string activeUnitName;
    private void OnMouseDown() {
        if (Main.pauseGame) return;
        
        team = transform.parent.tag;
        Debug.Log(team);
        if (team != Main.activeTeam) return;
        
        activeUnit = gameObject;
        
        if (!listContains(Constants.helpZones, activeUnit.transform.parent.parent.tag))
            unitForCoins = activeUnit.GetComponent<Unit>();
        
        if (lastActiveUnit != null && lastActiveUnit != activeUnit && 
            activeUnit.transform.parent.parent.tag != Constants.HELP_COINS_ZONE)
            NewUnitActiveted();
        
        lastActiveUnit = activeUnit;
        
        _controllableObject = GetComponent<IControllable>();
        
        String unitTag = transform.parent.parent.tag;
        
        if (unitTag == Constants.HAND_ZONE) UseCoin();
        if (unitTag == Constants.RECRUIT_ZONE)
            unitToRecruit = unitForCoins.gameObject;
    }

    private void UseCoin() {
        HideHelpCoins();
        if (IsRoyal(GetCoinTypeByName(RemoveCLONEinString(lastActiveUnit.name))))
            if (UnitExist(CoinType.ROYAL_GUARD))
                ShowHelpCoins(true);
            else ShowHelpCoins(false);
        else ShowHelpCoins(true);
        ChangeHelpCoinFaceUp();
        if (GetAllFreeTeamBases().Count == 0 && !UnitExist(activeUnit.GetComponent<Unit>().GetUnitType()))
            HideHelpCoinFaceUp();
        activatedUnitGO = GetGOByCoinType(GetCoinTypeByName(RemoveCLONEinString(lastActiveUnit.name)));
    }

    private void ShowHelpCoins(Boolean showFaceUpCoin) {
        if (Main.activeTeam == Constants.BLACK) {
            if (showFaceUpCoin)
                Main.blackHelpCoinFaceUp.gameObject.SetActive(true);
            Main.blackHelpCoinFaceDown.gameObject.SetActive(true);
        }
        else {
            if (showFaceUpCoin)
                Main.whiteHelpCoinFaceUp.gameObject.SetActive(true);
            Main.whiteHelpCoinFaceDown.gameObject.SetActive(true);
        }
    }
    
    private void HideHelpCoins() {
        if (Main.activeTeam == Constants.BLACK) {
            Main.blackHelpCoinFaceUp.gameObject.SetActive(false);
            Main.blackHelpCoinFaceDown.gameObject.SetActive(false);
        }
        else {
            Main.whiteHelpCoinFaceUp.gameObject.SetActive(false);
            Main.whiteHelpCoinFaceDown.gameObject.SetActive(false);
        }
    }
    
    private void HideHelpCoinFaceUp() {
        if (Main.activeTeam == Constants.BLACK)
            Main.blackHelpCoinFaceUp.gameObject.SetActive(false);
        else Main.whiteHelpCoinFaceUp.gameObject.SetActive(false);
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
    
    private Boolean listContains(List<string> stringList, string str) {
        if (stringList.Count == 0) return false;
        foreach (string _str in stringList)
            if (_str == str) return true;
        return false;
    }
    
    private List<Vector2> GOListToV2List(List<GameObject> list) {
        List<Vector2> positionsList = new List<Vector2>();
        foreach (GameObject unit in list) {
            positionsList.Add(unit.transform.position);
        }
        return positionsList;
    }
    
    private Boolean IsRoyal(CoinType type) {
        if (type == CoinType.ROYAL_BLACK || type == CoinType.ROYAL_WHITE) return true;
        return false;
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
    
    private List<GameObject> GetAllUnits() {
        List<GameObject> unitsList = new List<GameObject>();
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.BLACK_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.WHITE_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        return unitsList;
    }

    private String RemoveCLONEinString(string str) {
        return str.Replace(Constants.CLONE, "");
    }

    private void ChangeHelpCoinFaceUp() {
        Sprite activeUnitSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        if (Main.activeTeam == Constants.BLACK)
            Main.blackHelpCoinFaceUp.GetComponent<SpriteRenderer>().sprite = activeUnitSprite;
        else Main.whiteHelpCoinFaceUp.GetComponent<SpriteRenderer>().sprite = activeUnitSprite;
    }

    private void NewUnitActiveted() {
        _controllableObject = unitForCoins.GetComponent<IControllable>();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.DestroyCoinFaceDownPoints();
    }

    private CoinType GetCoinTypeByName(string name) {
        switch (name) {
            case Constants.ROYAL_BLACK: return CoinType.ROYAL_BLACK;
            case Constants.ROYAL_WHITE: return CoinType.ROYAL_WHITE;
            case Constants.ARCHER: return CoinType.ARCHER;
            case Constants.BANNERMAN: return CoinType.BANNERMAN;
            case Constants.BERSERKER: return CoinType.BERSERKER;
            case Constants.BISHOP: return CoinType.BISHOP;
            case Constants.CAVALRY: return CoinType.CAVALRY;
            case Constants.CROSSBOWMAN: return CoinType.CROSSBOWMAN;
            case Constants.EARL: return CoinType.EARL;
            case Constants.ENSIGN: return CoinType.ENSIGN;
            case Constants.FOOTMAN: return CoinType.FOOTMAN;
            case Constants.HERALD: return CoinType.HERALD;
            case Constants.KNIGHT: return CoinType.KNIGHT;
            case Constants.LANCER: return CoinType.LANCER;
            case Constants.LIGHT_CAVALRY: return CoinType.LIGHT_CAVALRY;
            case Constants.MARSHAL: return CoinType.MARSHAL;
            case Constants.MERCENARY: return CoinType.MERCENARY;
            case Constants.PIKEMAN: return CoinType.PIKEMAN;
            case Constants.ROYAL_GUARD: return CoinType.ROYAL_GUARD;
            case Constants.SAPPER: return CoinType.SAPPER;
            case Constants.SCOUT: return CoinType.SCOUT;
            case Constants.SIEGE_TOWER: return CoinType.SIEGE_TOWER;
            case Constants.SWORDSMAN: return CoinType.SWORDSMAN;
            case Constants.TREBUCHET: return CoinType.TREBUCHET;
            case Constants.WARRIOR_PRIEST: return CoinType.WARRIOR_PRIEST;
            case Constants.WAR_WAGON: return CoinType.WAR_WAGON;
            default: return CoinType.NULL;
        }
    }
    
    private GameObject GetGOByCoinType(CoinType coinType) {
        switch (coinType) {
            case CoinType.ROYAL_BLACK: return royalBlack;
            case CoinType.ROYAL_WHITE: return royalWhite;
            case CoinType.ARCHER: return archer;
            case CoinType.BANNERMAN: return bannerman;
            case CoinType.BERSERKER: return berserker;
            case CoinType.BISHOP: return bishop;
            case CoinType.CAVALRY: return cavalry;
            case CoinType.CROSSBOWMAN: return crossbowman;
            case CoinType.EARL: return earl;
            case CoinType.ENSIGN: return ensign;
            case CoinType.FOOTMAN: return footman;
            case CoinType.HERALD: return herald;
            case CoinType.KNIGHT: return knight;
            case CoinType.LANCER: return lancer;
            case CoinType.LIGHT_CAVALRY: return lightCavalry;
            case CoinType.MARSHAL: return marshal;
            case CoinType.MERCENARY: return mercenary;
            case CoinType.PIKEMAN: return pikeman;
            case CoinType.ROYAL_GUARD: return royalGuard;
            case CoinType.SAPPER: return sapper;
            case CoinType.SCOUT: return scout;
            case CoinType.SIEGE_TOWER: return siegeTower;
            case CoinType.SWORDSMAN: return swordsman;
            case CoinType.TREBUCHET: return trebuchet;
            case CoinType.WARRIOR_PRIEST: return warrior_priest;
            case CoinType.WAR_WAGON: return war_wagon;
            default: return null;
        }
    }
}
