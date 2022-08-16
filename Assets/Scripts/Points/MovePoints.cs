using UnityEngine;

public class MovePoints : MonoBehaviour {
    private IControllable _controllableObject;
    public static Vector2 movePosition;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceUp.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        movePosition = transform.position;
        _controllableObject.Move();
        _controllableObject.DestroyHandCoin();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.DestroyPoints();
        _controllableObject.ChangeActiveTeam();
    }
}
