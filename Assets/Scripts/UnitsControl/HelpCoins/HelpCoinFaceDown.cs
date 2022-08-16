using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCoinFaceDown : MonoBehaviour {
    public GameObject claimInitiativePoint, passPoint, recruitPoint;
    
    private string team;
    public static Unit unit;
    
    private Transform parent;
    
    private void OnMouseDown() {
        Main.faceUp = false;
        team = transform.parent.tag;
        unit = ActivateUnit.unitForCoins;
        unit.HideHelpCoins();
        
        if (Main.activeTeam == Constants.BLACK)
            parent = GameObject.FindGameObjectsWithTag(Constants.COIN_FACE_DOWN_POINTS_ZONE)[0].transform.Find(Constants.BLACK_COIN_FACE_DOWN_POINTS);
        else parent = GameObject.FindGameObjectsWithTag(Constants.COIN_FACE_DOWN_POINTS_ZONE)[0].transform.Find(Constants.WHITE_COIN_FACE_DOWN_POINTS);
        
        CreateRecruitPoints();
        CreatePassPoint();
        CreateClaimInitiativePoint();
    }

    private void CreateClaimInitiativePoint() {
        if (Main.initiativeHasBeenChanged) return;
        if (Main.activeTeam == Main.initiativeTeam) return;
        CreatePoint(claimInitiativePoint, Constants.initiativeCoinPosition, parent);
        Main.initiativeHasBeenChanged = true;
    }

    private void CreatePassPoint() {
        Main._passCoin.gameObject.SetActive(true);
        CreatePoint(passPoint, Constants.passCoinPosition, parent);
    }

    private void CreateRecruitPoints() {
        if (team == Constants.BLACK) {
            foreach (Vector2 position in Constants.BlackRecruitZonePosition)
                if (ExistRecruitCoin(position))
                    CreatePoint(recruitPoint, position, parent);
        }
        else
            foreach (Vector2 position in Constants.WhiteRecruitZonePosition)
                if (ExistRecruitCoin(position))
                    CreatePoint(recruitPoint, position, parent);
    }

    private Boolean ExistRecruitCoin(Vector2 position) { // добавить проверку на numOfUnitsToRecruit
        foreach (GameObject coin in GetAllRecruitCoin())
            if (Vector3ToVector2(coin.transform.position) == position)
                return true;
        return false;
    }
    
    private Vector2 Vector3ToVector2(Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }
    
    private List<GameObject> GetAllRecruitCoin() {
        List<GameObject> coinList = new List<GameObject>();
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.RECRUIT_ZONE)[0].transform.Find(Constants.BLACK_RECRUIT_ZONE).transform)
            coinList.Add(unit.gameObject);
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.RECRUIT_ZONE)[0].transform.Find(Constants.WHITE_RECRUIT_ZONE).transform)
            coinList.Add(unit.gameObject);
        return coinList;
    }

    private void CreatePoint(GameObject point, Vector2 position, Transform parent) {
        GameObject _point = Instantiate(point, position, Quaternion.identity, parent);
        SpriteRenderer sprite = _point.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = Constants.POINT_ORDER_IN_LAYER;
    }
}
