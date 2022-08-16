using UnityEngine;

public class ClaimInitiativePoints : MonoBehaviour {
    public Sprite blackCoin, whiteCoin;
    
    private IControllable _controllableObject;
    
    private void OnMouseDown() {
        Unit unit = HelpCoinFaceDown.unit;
        _controllableObject = unit.GetComponent<IControllable>();
        ChangeInitiativeTeam();
        _controllableObject.DestroyCoinFaceDownPoints();
        _controllableObject.DestroyHandCoin();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.DestroyPoints();
        _controllableObject.ChangeActiveTeam();
    }
    
    public void ChangeInitiativeTeam() {
        if (Main.initiativeTeam == Constants.BLACK) {
            Main.initiativeTeam = Constants.WHITE;
            Main.initiativeTeamCoinSprite.sprite = whiteCoin;
        }
        else {
            Main.initiativeTeam = Constants.BLACK;
            Main.initiativeTeamCoinSprite.sprite = blackCoin;
        }
    }
}
