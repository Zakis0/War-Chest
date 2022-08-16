using System;
using System.Collections.Generic;
using UnityEngine;

public class RecruitPoints : MonoBehaviour {
    private IControllable _controllableObject;
    
    public GameObject
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
        warriorPriest,
        warWagon;

    private CoinType coinType;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceDown.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        _controllableObject.DestroyHandCoin();
        RecruitUnit();
        _controllableObject.DestroyCoinFaceDownPoints();
        _controllableObject.ChangeActiveTeam();
        DestroyRecruitCoin();
    }
    
    private void RecruitUnit() {
        coinType = GetCoinTypeByPosition(transform.position);
        Main.NumOfUnitsToRecruit[coinType]--;
        if (Main.activeTeam == Constants.BLACK)
            Main.blackDiscard.Add(coinType);
        else Main.whiteDiscard.Add(coinType);
        Main.faceUp = true;
        _controllableObject.CreateDiscardCoin(GetGOByCoinType(coinType));
        Main.faceUp = false;
    }

    private void DestroyRecruitCoin() {
        if (Main.NumOfUnitsToRecruit[coinType] == 0)
            Destroy(GetCoinGOByPosition(transform.position));
    }

    private CoinType GetCoinTypeByPosition(Vector2 position) {
        foreach (GameObject coin in GetAllRecruitCoin())
            if (Vector3ToVector2(coin.transform.position) == position)
                return coin.GetComponent<Unit>().GetUnitType();
        return CoinType.NULL;
    }
    
    private GameObject GetCoinGOByPosition(Vector2 position) {
        foreach (GameObject coin in GetAllRecruitCoin())
            if (Vector3ToVector2(coin.transform.position) == position)
                return coin;
        return null;
    }
    
    private List<GameObject> GetAllRecruitCoin() {
        List<GameObject> coinList = new List<GameObject>();
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.RECRUIT_ZONE)[0].transform.Find(Constants.BLACK_RECRUIT_ZONE).transform)
            coinList.Add(unit.gameObject);
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.RECRUIT_ZONE)[0].transform.Find(Constants.WHITE_RECRUIT_ZONE).transform)
            coinList.Add(unit.gameObject);
        return coinList;
    }
    
    private Vector2 Vector3ToVector2(Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }
    
    private GameObject GetGOByCoinType(CoinType unit) {
        switch (unit) {
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
            case CoinType.WARRIOR_PRIEST: return warriorPriest;
            case CoinType.WAR_WAGON: return warWagon;
            default: return null;
        }
    }
}
