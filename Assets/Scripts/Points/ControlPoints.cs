using UnityEngine;

public class ControlPoints : MonoBehaviour {
    private IControllable _controllableObject;
    public static Vector2 controlPosition;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceUp.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        controlPosition = transform.position;
        _controllableObject.Control();
        _controllableObject.DestroyHandCoin();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.DestroyPoints();
        _controllableObject.ChangeActiveTeam();
    }
}
