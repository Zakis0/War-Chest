using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Constants
{
    public const float MOVE_X = 0.866f;
    public const float MOVE_Y = 0.5f;

    public const string BLACK = "Black";
    public const string WHITE = "White";
    public const string BLACK_UNIT = "BlackUnit";
    public const string WHITE_UNIT = "WhiteUnit";
    public const string BASES = "Bases";
    public const string BLACK_BASES = "BlackBases";
    public const string WHITE_BASES = "WhiteBases";
    public const string RECRUIT_ZONE = "RecruitZone";
    public const string HAND_ZONE = "HandZone";
    public const string UNIT_ZONE = "UnitZone";
    public const string DEPLOY_POINTS_ZONE = "DeployPointsZone";
    public const string COIN_FACE_DOWN_POINTS_ZONE = "CoinFaceDownPointsZone";
    public const string BLACK_COIN_FACE_DOWN_POINTS = "blackCoinFaceDownPoints";
    public const string WHITE_COIN_FACE_DOWN_POINTS = "whiteCoinFaceDownPoints";
    public const string DISCARD_ZONE = "DiscardZone";
    public const string BLACK_DISCARD_ZONE = "blackDiscardZone";
    public const string WHITE_DISCARD_ZONE = "whiteDiscardZone";
    public const string HELP_COINS_ZONE = "HelpCoinsZone";
    public const string BLACK_UNITS_ZONE = "BlackUnitsZone";
    public const string WHITE_UNITS_ZONE = "WhiteUnitsZone";
    public const string BLACK_DEPLOY_POINTS = "BlackDeployPoints";
    public const string WHITE_DEPLOY_POINTS = "WhiteDeployPoints";
    public const string BLACK_RECRUIT_ZONE = "blackRecruitZone";
    public const string WHITE_RECRUIT_ZONE = "whiteRecruitZone";
    // public const string BAG_ZONE = "BagZone";
    // public const string BLACK_BAG_ZONE = "blackBagZone";
    // public const string WHITE_BAG_ZONE = "whiteBagZone";
    public const string BLACK_HELP_COINS = "blackHelpCoins";
    public const string WHITE_HELP_COINS = "whiteHelpCoins";
    public const string BLACK_HELP_COIN_FACE_UP = "blackHelpCoinFaceUp";
    public const string WHITE_HELP_COIN_FACE_UP = "whiteHelpCoinFaceUp";
    public const string BOLSTER = "Bolster";
    public const string BOLSTERS = "Bolsters";
    public const string POINTS = "Points";
    public const string UNTAGGED = "Untagged";
    public const string CLONE = "(Clone)";
    
    public const string ROYAL_BLACK = "royalCoinBlack";
    public const string ROYAL_WHITE = "royalCoinWhite";
    public const string ARCHER = "archer";
    public const string BANNERMAN = "bannerman";
    public const string BERSERKER = "berserker";
    public const string BISHOP = "bishop";
    public const string CAVALRY = "cavalry";
    public const string CROSSBOWMAN = "crossbowman";
    public const string EARL = "earl";
    public const string ENSIGN = "ensign";
    public const string FOOTMAN = "footman";
    public const string HERALD = "herald";
    public const string KNIGHT = "knight";
    public const string LANCER = "lancer";
    public const string LIGHT_CAVALRY = "lightCavalry";
    public const string MARSHAL = "marshal";
    public const string MERCENARY = "mercenary";
    public const string PIKEMAN = "pikeman";
    public const string ROYAL_GUARD = "royalGuard";
    public const string SAPPER = "sapper";
    public const string SCOUT = "scout";
    public const string SIEGE_TOWER = "siegeTower";
    public const string SWORDSMAN = "swordsman";
    public const string TREBUCHET = "trebuchet";
    public const string WARRIOR_PRIEST = "warriorPriest";
    public const string WAR_WAGON = "warWagon";
    
    public const string TO_DESTROY = "New Game Object";

    public static List<string> helpZones = new List<string>() {
        UNIT_ZONE,
        HELP_COINS_ZONE,
        DISCARD_ZONE,
    };

    public const short START_BOLSTER_ORDER_IN_LAYER = 5;

    public const short START_BASES_1VS1 = 2;
    public const short START_BASES_2VS2 = 3;

    public const short NUM_BASES_TO_WIN_1VS1 = 6;
    public const short NUM_BASES_TO_WIN_2VS2 = 8;
    
    public const short MAX_NUM_OF_UNITS_1VS1 = 4;
    public const short MAX_NUM_OF_UNITS_2VS2 = 3;
    
    public const short MAX_UNIT_HP = 5;
    public const short POINT_ORDER_IN_LAYER = 4 + MAX_UNIT_HP;

    public const short MAX_HP_TO_ATTACK_BISHOP = 1;
    public const short MIN_HP_TO_ATTACK_KNIGHT = 2;

    public const short HAND_LIMIT = 3;
    
    public static Vector3 LOCAL_SCALE = new Vector3(1, 1, 1);
    public static Vector3 DEPLOY_POINTS_LOCAL_SCALE = LOCAL_SCALE / 2;
    public static Vector2 BOLSTER_BIAS = new Vector2(0.05f, 0.09f);

    public const short START_NUM_OF_UNIT_IN_BAG = 2;
    
    public const short MAX_ARCHER_HP = 5;
    public const short MAX_BANNERMAN_HP = 5;
    public const short MAX_BERSERKER_HP = 5;
    public const short MAX_BISHOP_HP = 5;
    public const short MAX_CAVALRY_HP = 5;
    public const short MAX_CROSSBOWMAN_HP = 5;
    public const short MAX_EARL_HP = 5;
    public const short MAX_ENSIGN_HP = 5;
    public const short MAX_FOOTMAN_HP = 5;
    public const short MAX_HERALD_HP = 5;
    public const short MAX_KNIGHT_HP = 5;
    public const short MAX_LANCER_HP = 5;
    public const short MAX_LIGHT_CAVALRY_HP = 5;
    public const short MAX_MARSHAL_HP = 5;
    public const short MAX_MERCENARY_HP = 5;
    public const short MAX_PIKEMAN_HP = 5;
    public const short MAX_ROYAL_GUARD_HP = 5;
    public const short MAX_SAPPER_HP = 5;
    public const short MAX_SCOUT_HP = 5;
    public const short MAX_SIEGE_TOWER_HP = 5;
    public const short MAX_SWORDSMAN_HP = 5;
    public const short MAX_TREBUCHET_HP = 5;
    public const short MAX_WARRIOR_PRIEST_HP = 5;
    public const short MAX_WAR_WAGON_HP = 5;
    
    public static Vector2 RayTop = new Vector2(0, 2 * MOVE_Y);
    public static Vector2 RayTopRight = new Vector2(MOVE_X, MOVE_Y);
    public static Vector2 RayBottomRight = new Vector2(MOVE_X, -MOVE_Y);
    public static Vector2 RayBottom = new Vector2(0, -MOVE_Y);
    public static Vector2 RayBottomLeft = new Vector2(-MOVE_X, -MOVE_Y);
    public static Vector2 RayTopLeft = new Vector2(-MOVE_X, MOVE_Y);
    
    public static List<Vector2> Circle1R = new List<Vector2>() {
        new (0, 2 * MOVE_Y),
        new (MOVE_X, MOVE_Y),
        new (MOVE_X, -MOVE_Y),
        new (0, -2 * MOVE_Y),
        new (-MOVE_X, -MOVE_Y),
        new (-MOVE_X, MOVE_Y),
    };
    
    public static List<Vector2> Circle2R = new List<Vector2>() {
        new (0, 4 * MOVE_Y),
        new (MOVE_X, 3 * MOVE_Y),
        new (2 * MOVE_X, 2 * MOVE_Y),
        new (2 * MOVE_X, 0),
        new (2 * MOVE_X, -2 * MOVE_Y),
        new (MOVE_X, -3 * MOVE_Y),
        new (0, -4 * MOVE_Y),
        new (-MOVE_X, -3 * MOVE_Y),
        new (-2 * MOVE_X, -2 * MOVE_Y),
        new (-2 * MOVE_X, 0),
        new (-2 * MOVE_X, 2 * MOVE_Y),
        new (-MOVE_X, 3 * MOVE_Y),
    };
    
    public static List<Vector2> Circle1R_AND_2R = new List<Vector2>() {
        new (0, 2 * MOVE_Y),
        new (MOVE_X, MOVE_Y),
        new (MOVE_X, -MOVE_Y),
        new (0, -2 * MOVE_Y),
        new (-MOVE_X, -MOVE_Y),
        new (-MOVE_X, MOVE_Y),
        new (0, 4 * MOVE_Y),
        new (MOVE_X, 3 * MOVE_Y),
        new (2 * MOVE_X, 2 * MOVE_Y),
        new (2 * MOVE_X, 0),
        new (2 * MOVE_X, -2 * MOVE_Y),
        new (MOVE_X, -3 * MOVE_Y),
        new (0, -4 * MOVE_Y),
        new (-MOVE_X, -3 * MOVE_Y),
        new (-2 * MOVE_X, -2 * MOVE_Y),
        new (-2 * MOVE_X, 0),
        new (-2 * MOVE_X, 2 * MOVE_Y),
        new (-MOVE_X, 3 * MOVE_Y),
    };
    
    public static List<Vector2> Rays2R = new List<Vector2>() {
        new (0, 4 * MOVE_Y),
        new (2 * MOVE_X, 2 * MOVE_Y),
        new (2 * MOVE_X, -2 * MOVE_Y),
        new (0, -4 * MOVE_Y),
        new (-2 * MOVE_X, -2 * MOVE_Y),
        new (-2 * MOVE_X, 2 * MOVE_Y),
    };
    
    public static List<Vector2> Rays3R = new List<Vector2>() {
        new (0, 6 * MOVE_Y),
        new (3 * MOVE_X, 3 * MOVE_Y),
        new (3 * MOVE_X, -3 * MOVE_Y),
        new (0, -6 * MOVE_Y),
        new (-3 * MOVE_X, -3 * MOVE_Y),
        new (-3 * MOVE_X, 3 * MOVE_Y),
    };
    
    public static List<Vector2> Rays2R_AND_3R = new List<Vector2>() {
        new (0, 4 * MOVE_Y),
        new (2 * MOVE_X, 2 * MOVE_Y),
        new (2 * MOVE_X, -2 * MOVE_Y),
        new (0, -4 * MOVE_Y),
        new (-2 * MOVE_X, -2 * MOVE_Y),
        new (-2 * MOVE_X, 2 * MOVE_Y),
        
        new (0, 6 * MOVE_Y),
        new (3 * MOVE_X, 3 * MOVE_Y),
        new (3 * MOVE_X, -3 * MOVE_Y),
        new (0, -6 * MOVE_Y),
        new (-3 * MOVE_X, -3 * MOVE_Y),
        new (-3 * MOVE_X, 3 * MOVE_Y),
    };

    public static List<Vector2> Bases = new List<Vector2>() {
        new (MOVE_X, -5 * MOVE_Y),
        new (-2 * MOVE_X, -4 * MOVE_Y),
        new (2 * MOVE_X, -2 * MOVE_Y),
        new (-3 * MOVE_X, -MOVE_Y),
        new (-MOVE_X, -MOVE_Y),
        new (MOVE_X, MOVE_Y),
        new (3 * MOVE_X, MOVE_Y),
        new (-2 * MOVE_X, 2 * MOVE_Y),
        new (2 * MOVE_X, 4 * MOVE_Y),
        new (-MOVE_X, 5 * MOVE_Y),
    };

    public static List<Vector2> AddBases = new List<Vector2>() {
        new (4 * MOVE_X, -2 * MOVE_Y),
        new (-5 * MOVE_X, -MOVE_Y),
        new (5 * MOVE_X, MOVE_Y),
        new (-4 * MOVE_X, 2 * MOVE_Y),
    };

    public static List<Vector2> StartBlackBases = new List<Vector2>() {
        new (2 * MOVE_X, 4 * MOVE_Y),
        new (-MOVE_X, 5 * MOVE_Y),
    };
    
    public static List<Vector2> StartWhiteBases = new List<Vector2>() {
        new (MOVE_X, -5 * MOVE_Y),
        new (-2 * MOVE_X, -4 * MOVE_Y),
    };

    public static Vector2 AddBlackBase = new (-4 * MOVE_X, 2 * MOVE_Y);
    public static Vector2 AddWhiteBase = new (4 * MOVE_X, -2 * MOVE_Y);

    public static List<Vector2> Board = new List<Vector2>() {
        new (0, -6 * MOVE_Y),
        new (-MOVE_X, -5 * MOVE_Y),
        new (MOVE_X, -5 * MOVE_Y),
        new (-2 * MOVE_X, -4 * MOVE_Y),
        new (0, -4 * MOVE_Y),
        new (2 * MOVE_X, -4 * MOVE_Y),
        new (-3 * MOVE_X, -3 * MOVE_Y),
        new (-MOVE_X, -3 * MOVE_Y),
        new (MOVE_X, -3 * MOVE_Y),
        new (3 * MOVE_X, -3 * MOVE_Y),
        new (-2 * MOVE_X, -2 * MOVE_Y),
        new (0, -2 * MOVE_Y),
        new (2 * MOVE_X, -2 * MOVE_Y),
        new (-3 * MOVE_X, -MOVE_Y),
        new (-MOVE_X, -MOVE_Y),
        new (MOVE_X, -MOVE_Y),
        new (3 * MOVE_X, -MOVE_Y),
        new (-2 * MOVE_X, 0),
        new (0, 0),
        new (2 * MOVE_X, 0),
        new (0, 6 * MOVE_Y),
        new (-MOVE_X, 5 * MOVE_Y),
        new (MOVE_X, 5 * MOVE_Y),
        new (-2 * MOVE_X, 4 * MOVE_Y),
        new (0, 4 * MOVE_Y),
        new (2 * MOVE_X, 4 * MOVE_Y),
        new (-3 * MOVE_X, 3 * MOVE_Y),
        new (-MOVE_X, 3 * MOVE_Y),
        new (MOVE_X, 3 * MOVE_Y),
        new (3 * MOVE_X, 3 * MOVE_Y),
        new (-2 * MOVE_X, 2 * MOVE_Y),
        new (0, 2 * MOVE_Y),
        new (2 * MOVE_X, 2 * MOVE_Y),
        new (-3 * MOVE_X, MOVE_Y),
        new (-MOVE_X, MOVE_Y),
        new (MOVE_X, MOVE_Y),
        new (3 * MOVE_X, MOVE_Y),
    };

    public static List<Vector2> AddBoard = new List<Vector2>() {
        new (-4 * MOVE_X, -2 * MOVE_Y),
        new (4 * MOVE_X, -2 * MOVE_Y),
        new (-4 * MOVE_X, 0),
        new (4 * MOVE_X, 0),
        new (-4 * MOVE_X, 2 * MOVE_Y),
        new (4 * MOVE_X, 2 * MOVE_Y),
        new (-5 * MOVE_X, -MOVE_Y),
        new (5 * MOVE_X, -MOVE_Y),
        new (-5 * MOVE_X, MOVE_Y),
        new (5 * MOVE_X, MOVE_Y),
    };

    public static List<Vector2> BlackRecruitZonePosition = new List<Vector2>() {
        new(5 * MOVE_X, 3 * MOVE_Y),
        new(6 * MOVE_X, 3 * MOVE_Y),
        new(7 * MOVE_X, 3 * MOVE_Y),
        new(8 * MOVE_X, 3 * MOVE_Y),
    };
    
    public static List<Vector2> WhiteRecruitZonePosition = new List<Vector2>() {
        new(-5 * MOVE_X, -3 * MOVE_Y),
        new(-6 * MOVE_X, -3 * MOVE_Y),
        new(-7 * MOVE_X, -3 * MOVE_Y),
        new(-8 * MOVE_X, -3 * MOVE_Y),
    };
    
    public static List<Vector2> BlackHandZonePosition = new List<Vector2>() {
        new(5 * MOVE_X, 6 * MOVE_Y),
        new(6 * MOVE_X, 6 * MOVE_Y),
        new(7 * MOVE_X, 6 * MOVE_Y),
    };
    
    public static List<Vector2> WhiteHandZonePosition = new List<Vector2>() {
        new(-5 * MOVE_X, -6 * MOVE_Y),
        new(-6 * MOVE_X, -6 * MOVE_Y),
        new(-7 * MOVE_X, -6 * MOVE_Y),
    };

    public static Vector2 initiativeCoinPosition = new Vector2(-6 * MOVE_X, 0);
    public static Vector2 passCoinPosition = new Vector2(6 * MOVE_X, 0);
    
    public static Vector2 blackHelpCoinFaceUpPositions = new Vector2(3 * MOVE_X, 6 * MOVE_Y);
    public static Vector2 blackHelpCoinFaceDownPositions = new Vector2(2 * MOVE_X, 6 * MOVE_Y);
    
    public static Vector2 whiteHelpCoinFaceUpPositions = new Vector2(-3 * MOVE_X, -6 * MOVE_Y);
    public static Vector2 whiteHelpCoinFaceDownPositions = new Vector2(-2 * MOVE_X, -6 * MOVE_Y);

    public static Vector2 startBlackDiscardZone = new(10 * MOVE_X, 8 * MOVE_Y);
    public static Vector2 startWhiteDiscardZone = new(-10 * MOVE_X, -8 * MOVE_Y);
    
    public static Vector2 changeBlackDiscardZone = new(0, -MOVE_Y);
    public static Vector2 changeWhiteDiscardZone = new(0, MOVE_Y);

    public static List<CoinType> Units = new List<CoinType>() {
        CoinType.ARCHER,
        CoinType.BANNERMAN,
        CoinType.BERSERKER,
        CoinType.BISHOP,
        CoinType.CAVALRY,
        CoinType.CROSSBOWMAN,
        CoinType.EARL,
        CoinType.ENSIGN,
        CoinType.FOOTMAN,
        CoinType.HERALD,
        CoinType.KNIGHT,
        CoinType.LANCER,
        CoinType.LIGHT_CAVALRY,
        CoinType.MARSHAL,
        CoinType.MERCENARY,
        CoinType.PIKEMAN,
        CoinType.ROYAL_GUARD,
        CoinType.SAPPER,
        CoinType.SCOUT,
        CoinType.SIEGE_TOWER,
        CoinType.SWORDSMAN,
        CoinType.TREBUCHET,
        CoinType.WARRIOR_PRIEST,
        CoinType.WAR_WAGON,
    };

    public static List<CoinType> readyUnits = new List<CoinType>() {
        CoinType.ARCHER,
        // CoinType.BANNERMAN,
        // CoinType.BERSERKER,
        // CoinType.BISHOP,
        // CoinType.CAVALRY,
        CoinType.CROSSBOWMAN,
        // CoinType.EARL,
        // CoinType.ENSIGN,
        // CoinType.FOOTMAN,
        // CoinType.HERALD,
        CoinType.KNIGHT,
        // CoinType.LANCER,
        CoinType.LIGHT_CAVALRY,
        // CoinType.MARSHAL,
        // CoinType.MERCENARY,
        CoinType.PIKEMAN,
        // CoinType.ROYAL_GUARD,
        // CoinType.SAPPER,
        CoinType.SCOUT,
        // CoinType.SIEGE_TOWER,
        // CoinType.SWORDSMAN,
        CoinType.TREBUCHET,
        // CoinType.WARRIOR_PRIEST,
        // CoinType.WAR_WAGON,
    };
}