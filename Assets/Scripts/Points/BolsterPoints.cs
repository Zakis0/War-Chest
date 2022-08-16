using UnityEngine;

public class BolsterPoints : MonoBehaviour {
    private IControllable _controllableObject;
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceUp.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        _controllableObject.Bolster();
        _controllableObject.DestroyHandCoinNotDiscard();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.DestroyPoints();
        _controllableObject.ChangeActiveTeam();
    }
}
