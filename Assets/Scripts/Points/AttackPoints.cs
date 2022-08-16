using UnityEngine;

public class AttackPoints : MonoBehaviour {
    private IControllable _controllableObject;
    public static Vector2 attackPosition;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceUp.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        attackPosition = transform.position;
        _controllableObject.Attack();
        _controllableObject.DestroyHandCoin();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.DestroyPoints();
        _controllableObject.ChangeActiveTeam();
    }
    
}