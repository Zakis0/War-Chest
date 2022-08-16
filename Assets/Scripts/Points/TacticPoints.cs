using UnityEngine;

public class TacticPoints : MonoBehaviour {
    private IControllable _controllableObject;
    public static Vector2 tacticPosition;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceUp.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        tacticPosition = transform.position;
        _controllableObject.Tactic(true, true, true, true);
    }
}