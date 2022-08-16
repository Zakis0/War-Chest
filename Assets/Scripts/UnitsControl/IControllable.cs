using System;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable {
    // void Activate();
    // void Deactivate();
    void LoseHP();
    void Move();
    void Control();
    // void CreateAttackPoints();
    void Attack();
    // void CreateTacticPoints();
    void Tactic(bool destroyHandCoin, bool destroyDeployPoint, bool destroyPoints, bool changeActiveTeam);
    // void CreateBolsterPoint();
    void DestroyLastBolster();
    void Bolster();
    void ChangeActiveTeam();
    void DestroyDeployPoint();
    void HideHelpCoins();
    void DestroyPoints();
    void DestroyHandCoin();
    void DestroyCoinFaceDownPoints();
    void DestroyHandCoinNotDiscard();
    void CreateDiscardCoin(GameObject coin);
    void printList(List<CoinType> list, string defaultText = "");
    void printList(List<GameObject> list, string defaultText = "");
    void printList(List<Vector2> list, string defaultText = "");
    short GetUnitHP();
    short GetUnitMaxHP();
    CoinType GetUnitType();
}
