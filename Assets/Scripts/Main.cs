using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;
using Update = UnityEngine.PlayerLoop.Update;
public class Main : MonoBehaviour {

    public Transform helpCoins, blackHelpCoins, whiteHelpCoins, blackUnitsZone, whiteUnitsZone, blackBases, whiteBases, blackRecruitZone, whiteRecruitZone, blackHandZone, whiteHandZone, addHexes, addBases;
    public GameObject initiativeCoin, passCoin, helpCoinFaceUp, helpCoinFaceDown, blackBase, whiteBase, temp;
    public Sprite blackTeam, whiteTeam;

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
        warriorPriest,
        warWagon;
    
    public static Boolean pauseGame;

    public static Boolean faceUp = true;
    
    public static short numOfWhiteControledBases;
    public static short numOfBlackControledBases;

    public static List<GameObject> blackControledBases = new List<GameObject>();
    public static List<GameObject> whiteControledBases = new List<GameObject>();

    public static List<Vector2> blackControledBasesPosition = Constants.StartBlackBases;
    public static List<Vector2> whiteControledBasesPosition = Constants.StartWhiteBases;
    
    public static List<Vector2> bases = Constants.Bases;
    public static List<Vector2> board = Constants.Board;

    public static Dictionary<CoinType, short> NumOfUnitsInBox = new Dictionary<CoinType, short>();
    public static Dictionary<CoinType, int> NumOfUnitsToRecruit = new Dictionary<CoinType, int>();

    public static Boolean game2VS2 = true;
    
    private int randInt;
    
    public static string activeTeam;
    public static string initiativeTeam;

    public static Boolean initiativeHasBeenChanged = false;

    public static SpriteRenderer initiativeTeamCoinSprite;
    
    public static GameObject _passCoin;

    private Boolean blackRunOut = false;
    private Boolean whiteRunOut = false;
    
    public static List<CoinType> chosenUnits = new List<CoinType>();

    public static List<CoinType> blackUnits;
    public static List<CoinType> whiteUnits;
    
    public static List<CoinType> blackBag;
    public static List<CoinType> whiteBag;

    public static List<CoinType> blackHand;
    public static List<CoinType> whiteHand;

    public static List<CoinType> blackDiscard = new List<CoinType>();
    public static List<CoinType> whiteDiscard = new List<CoinType>();

    public static GameObject blackHelpCoinFaceUp;
    public static GameObject blackHelpCoinFaceDown;
    
    public static GameObject whiteHelpCoinFaceUp;
    public static GameObject whiteHelpCoinFaceDown;

    private IControllable _controllableObject;
    
    private short numOfBaseToWin;
    private short maxNumOfUnits;

    private void Start() {
        // GameObject unit = Instantiate(temp, new Vector2(0f, 0f), Quaternion.identity, blackUnitsZone);
        // unit.tag = Constants.BLACK_UNIT;
        
        blackHelpCoinFaceUp = Instantiate(helpCoinFaceUp, Constants.blackHelpCoinFaceUpPositions, Quaternion.identity, blackHelpCoins);
        blackHelpCoinFaceDown = Instantiate(helpCoinFaceDown, Constants.blackHelpCoinFaceDownPositions, Quaternion.identity, blackHelpCoins);

        whiteHelpCoinFaceUp = Instantiate(helpCoinFaceUp, Constants.whiteHelpCoinFaceUpPositions, Quaternion.identity, whiteHelpCoins);
        whiteHelpCoinFaceDown = Instantiate(helpCoinFaceDown, Constants.whiteHelpCoinFaceDownPositions, Quaternion.identity, whiteHelpCoins);
        
        blackHelpCoinFaceUp.name = Constants.BLACK_HELP_COIN_FACE_UP;
        whiteHelpCoinFaceUp.name = Constants.BLACK_HELP_COIN_FACE_UP;
        
        blackHelpCoinFaceUp.gameObject.SetActive(false);
        blackHelpCoinFaceDown.gameObject.SetActive(false);
        
        whiteHelpCoinFaceUp.gameObject.SetActive(false);
        whiteHelpCoinFaceDown.gameObject.SetActive(false);

        randInt = Random.Range(0, 2);
        activeTeam = new [] {Constants.BLACK, Constants.WHITE}[randInt];

        initiativeTeam = activeTeam;
        
        GameObject _initiativeCoin = Instantiate(initiativeCoin, Constants.initiativeCoinPosition, Quaternion.identity, helpCoins);
        initiativeTeamCoinSprite = _initiativeCoin.GetComponent<SpriteRenderer>();
        initiativeTeamCoinSprite.sprite = null;
        if (initiativeTeam == Constants.BLACK) {
            initiativeTeamCoinSprite.sprite = blackTeam;
        }
        else {
            initiativeTeamCoinSprite.sprite = whiteTeam;
        }
        
        _passCoin = Instantiate(passCoin, Constants.passCoinPosition, Quaternion.identity, helpCoins);
        _passCoin.gameObject.SetActive(false);
        
        if (game2VS2) {
            addHexes.gameObject.SetActive(true);
            addBases.gameObject.SetActive(true);
            
            numOfBaseToWin = Constants.NUM_BASES_TO_WIN_2VS2;

            maxNumOfUnits = Constants.MAX_NUM_OF_UNITS_2VS2;
            
            numOfWhiteControledBases = Constants.START_BASES_2VS2;
            numOfBlackControledBases = Constants.START_BASES_2VS2;
            
            blackControledBasesPosition.Add(Constants.AddBlackBase);
            whiteControledBasesPosition.Add(Constants.AddWhiteBase);
            
            bases.AddRange(Constants.AddBases);
            board.AddRange(Constants.AddBoard);
        }
        else {
            addHexes.gameObject.SetActive(false);
            addBases.gameObject.SetActive(false);
            
            numOfBaseToWin = Constants.NUM_BASES_TO_WIN_1VS1;
            
            maxNumOfUnits = Constants.MAX_NUM_OF_UNITS_1VS1;
            
            numOfWhiteControledBases = Constants.START_BASES_1VS1;
            numOfBlackControledBases = Constants.START_BASES_1VS1;
        }
        
        blackUnits = GetUnits(maxNumOfUnits);
        whiteUnits = GetUnits(maxNumOfUnits);
        
        blackBag = fillStartBag(blackUnits, Constants.BLACK);
        whiteBag = fillStartBag(whiteUnits, Constants.WHITE);
        
        blackHand = fillHand(Constants.BLACK);
        whiteHand = fillHand( Constants.WHITE);

        CreateCoins(blackHand, Constants.BlackHandZonePosition, blackHandZone, Constants.HAND_LIMIT);
        CreateCoins(whiteHand, Constants.WhiteHandZonePosition, whiteHandZone, Constants.HAND_LIMIT);
        
        CreateCoins(blackUnits, Constants.BlackRecruitZonePosition, blackRecruitZone, maxNumOfUnits);
        CreateCoins(whiteUnits, Constants.WhiteRecruitZonePosition, whiteRecruitZone, maxNumOfUnits);

        blackControledBases = addStartBasesToList(blackControledBasesPosition, blackBase, blackBases);
        whiteControledBases = addStartBasesToList(whiteControledBasesPosition, whiteBase, whiteBases);
    }

    private GameObject GetGOByCoinType(CoinType unit) {
        switch (unit) {
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
            case CoinType.WARRIOR_PRIEST: return warriorPriest;
            case CoinType.WAR_WAGON: return warWagon;
            default: return null;
        }
    }

    private List<GameObject> getUnitByItType(CoinType type) {
        List<GameObject> resultList = new List<GameObject>();
        List<GameObject> unitsList = GetAllUnits();
        foreach (GameObject unit in unitsList)
            if (unit.GetComponent<Unit>().GetUnitType() == type)
                resultList.Add(unit);
        return resultList;
    }
    
    private List<GameObject> GetAllUnits() {
        List<GameObject> unitsList = new List<GameObject>();
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.BLACK_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        foreach (Transform unit in GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.Find(Constants.WHITE_UNITS_ZONE).transform)
            unitsList.Add(unit.gameObject);
        return unitsList;
    }
    
    private List<CoinType> fillBag(string team) {
        List<CoinType> discard = new List<CoinType>();
        if (team == Constants.BLACK) {
            discard = blackDiscard;
            blackDiscard = new List<CoinType>();
        }
        else {
            discard = whiteDiscard;
            whiteDiscard = new List<CoinType>();
        }
        ClearDiscardZone(team);
        return discard;
    }

    private void ClearDiscardZone(string team) {
        if (team == Constants.BLACK)
            foreach (Transform coin in GameObject.FindGameObjectsWithTag(Constants.DISCARD_ZONE)[0].transform.Find(Constants.BLACK_DISCARD_ZONE))
                Destroy(coin.gameObject);
        else
            foreach (Transform coin in GameObject.FindGameObjectsWithTag(Constants.DISCARD_ZONE)[0].transform.Find(Constants.WHITE_DISCARD_ZONE))
                Destroy(coin.gameObject);
    }
    
    private List<CoinType> fillStartBag(List<CoinType> units, String team) {
        List<CoinType> bag = new List<CoinType>();
        foreach (CoinType unit in units) {
            bag.Add(unit);
            bag.Add(unit);
        }
        if (team == Constants.BLACK)
            bag.Add(CoinType.ROYAL_BLACK);
        else if (team == Constants.WHITE)
            bag.Add(CoinType.ROYAL_WHITE);
        return bag;
    }

    private List<CoinType> fillHand(string team) {
        List<CoinType> hand = new List<CoinType>();
        int RandPos;
        for (short i = 0; i < Constants.HAND_LIMIT; i++) {
            if (team == Constants.BLACK) {
                if (blackBag.Count == 0) blackBag = fillBag(team);

                RandPos = Random.Range(0, blackBag.Count);

                if (blackBag.Count != 0) {
                    hand.Add(blackBag[RandPos]);
                    blackBag.RemoveAt(RandPos);
                }
                else break;
            }
            else if (team == Constants.WHITE) {
                if (whiteBag.Count == 0) whiteBag = fillBag(team);

                RandPos = Random.Range(0, whiteBag.Count);

                if (whiteBag.Count != 0) {
                    hand.Add(whiteBag[RandPos]);
                    whiteBag.RemoveAt(RandPos);
                }
                else break;
            }
            else break;
        }
        return hand;
    }
    
    private void CreateCoins(List<CoinType> coinsList, List<Vector2> zoneList, Transform zoneTransform, int numOfCoins) {
        for (int i = 0; i < numOfCoins; i++) {
            Instantiate(GetGOByCoinType(coinsList[i]), zoneList[i], Quaternion.identity, zoneTransform);
        }
    }

    private List<GameObject> addStartBasesToList(List<Vector2> baseListVector2, GameObject baseGO, Transform baseTransform) {
        List<GameObject> baseListGO = new List<GameObject>();
        foreach (Vector2 basePosition in baseListVector2) {
            GameObject _base = Instantiate(baseGO, basePosition, Quaternion.identity, baseTransform);
            baseListGO.Add(_base);
        }
        return baseListGO;
    }
    
    public Boolean listContains(List<CoinType> typeList, CoinType unitType) {
        if (typeList.Count == 0) return false;
        foreach (CoinType type in typeList)
            if (type == unitType) return true;
        return false;
    }
    
    private void printList(List<CoinType> list, string defaultText = "") {
        string res = defaultText;
        foreach (var el in list)
            res += el.ToString() + " ";
        Debug.Log(res);
    }
    
    private void printList(List<GameObject> list, string defaultText = "") {
        string res = defaultText;
        foreach (var el in list)
            res += el.ToString() + " ";
        Debug.Log(res);
    }
    
    private void printDict(Dictionary<CoinType, short> dictionary, List<CoinType> listCoinType, string defaultText = "") {
        string res = defaultText;
        foreach (var el in listCoinType)
            res += el + ": " + dictionary[el] + ", ";
        Debug.Log(res);
    }
    
    private void printDict(Dictionary<CoinType, int> dictionary, List<CoinType> listCoinType, string defaultText = "") {
        string res = defaultText;
        foreach (var el in listCoinType)
            res += el + ": " + dictionary[el] + ", ";
        Debug.Log(res);
    }

    private List<CoinType> GetUnits(short numOfUnits) {
        List<CoinType> bag = new List<CoinType>();
        for (int i = 0; i < numOfUnits; i++) {
            CoinType unit;
            do {
                unit = Constants.Units[Random.Range(0, Constants.Units.Count)];
            } while(listContains(chosenUnits, unit) || !listContains(Constants.readyUnits, unit)); // temp
            bag.Add(unit);
            NumOfUnitsInBox[unit] = 0;
            NumOfUnitsToRecruit[unit] = GetUnitMaxHPbyCointType(unit) - Constants.START_NUM_OF_UNIT_IN_BAG;
            chosenUnits.Add(unit);
        }
        return bag;
    }

    private short GetUnitMaxHPbyCointType(CoinType unit) {
        switch (unit) {
            case CoinType.ARCHER: return Constants.MAX_ARCHER_HP;
            case CoinType.BANNERMAN: return Constants.MAX_BANNERMAN_HP;
            case CoinType.BERSERKER: return Constants.MAX_BERSERKER_HP;
            case CoinType.BISHOP: return Constants.MAX_BISHOP_HP;
            case CoinType.CAVALRY: return Constants.MAX_CAVALRY_HP;
            case CoinType.CROSSBOWMAN: return Constants.MAX_CROSSBOWMAN_HP;
            case CoinType.EARL: return Constants.MAX_EARL_HP;
            case CoinType.ENSIGN: return Constants.MAX_ENSIGN_HP;
            case CoinType.FOOTMAN: return Constants.MAX_FOOTMAN_HP;
            case CoinType.HERALD: return Constants.MAX_HERALD_HP;
            case CoinType.KNIGHT: return Constants.MAX_KNIGHT_HP;
            case CoinType.LANCER: return Constants.MAX_LANCER_HP;
            case CoinType.LIGHT_CAVALRY: return Constants.MAX_LIGHT_CAVALRY_HP;
            case CoinType.MARSHAL: return Constants.MAX_MARSHAL_HP;
            case CoinType.MERCENARY: return Constants.MAX_MERCENARY_HP;
            case CoinType.PIKEMAN: return Constants.MAX_PIKEMAN_HP;
            case CoinType.ROYAL_GUARD: return Constants.MAX_ROYAL_GUARD_HP;
            case CoinType.SAPPER: return Constants.MAX_SAPPER_HP;
            case CoinType.SCOUT: return Constants.MAX_SCOUT_HP;
            case CoinType.SIEGE_TOWER: return Constants.MAX_SIEGE_TOWER_HP;
            case CoinType.SWORDSMAN: return Constants.MAX_SWORDSMAN_HP;
            case CoinType.TREBUCHET: return Constants.MAX_TREBUCHET_HP;
            case CoinType.WARRIOR_PRIEST: return Constants.MAX_WARRIOR_PRIEST_HP;
            case CoinType.WAR_WAGON: return Constants.MAX_WAR_WAGON_HP;
            default: return 0;
        }
    }

    private void Update() {
        if (!pauseGame) {
            if (Input.GetKeyUp(KeyCode.Space)) {
                Debug.Log(activeTeam);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl)) {
                
            }
            checkWin();
            checkHands();
        }
        DestroyToDestroys();
    }
    
    private void checkHands() {
        if (blackHand.Count == 0 && whiteHand.Count != 0 && activeTeam == Constants.BLACK)
            activeTeam = Constants.WHITE;
        if (whiteHand.Count == 0 && blackHand.Count != 0 && activeTeam == Constants.WHITE)
            activeTeam = Constants.BLACK;
        if (blackHand.Count == 0) blackRunOut = true;
        if (whiteHand.Count == 0) whiteRunOut = true;
        if (blackRunOut && whiteRunOut) NewRound();
    }

    private void NewRound() {
        activeTeam = initiativeTeam;
        initiativeHasBeenChanged = false;
        
        blackRunOut = false;
        whiteRunOut = false;

        blackHand = fillHand(Constants.BLACK);
        whiteHand = fillHand(Constants.WHITE);
        
        CreateCoins(blackHand, Constants.BlackHandZonePosition, blackHandZone, blackHand.Count);
        CreateCoins(whiteHand, Constants.WhiteHandZonePosition, whiteHandZone, whiteHand.Count);
    }

    private void DestroyToDestroys() {
        try {
            Destroy(GameObject.Find(Constants.TO_DESTROY));
        }
        catch (UnityException) {}
    }

    private void checkWin() {
        if (numOfBlackControledBases == numOfBaseToWin)
            Win(Constants.BLACK);
        if (numOfWhiteControledBases == numOfBaseToWin)
            Win(Constants.WHITE);
    }

    private void Win(string team) {
        Debug.Log(team + " win!");
        pauseGame = true;
    }
}
