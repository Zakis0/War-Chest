using UnityEngine;

public class PassPoints : MonoBehaviour {
    private IControllable _controllableObject;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceDown.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        _controllableObject.DestroyHandCoin();
        _controllableObject.DestroyCoinFaceDownPoints();
        _controllableObject.ChangeActiveTeam();
    }
}
