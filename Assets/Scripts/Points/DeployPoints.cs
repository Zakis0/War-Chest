using Unity.VisualScripting;
using UnityEngine;

public class DeployPoints : MonoBehaviour {
    private IControllable _controllableObject;
    public static Vector2 deployPosition;
    public static GameObject createdUnit;
    
    private void OnMouseDown() {
        deployPosition = transform.position;
        createdUnit = ActivateUnit.activatedUnitGO;
        Transform deployTransform;
        if (Main.activeTeam == Constants.BLACK)
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.
                Find(Constants.BLACK_UNITS_ZONE);
        else
            deployTransform = GameObject.FindGameObjectsWithTag(Constants.UNIT_ZONE)[0].transform.
                Find(Constants.WHITE_UNITS_ZONE);
        GameObject unit = Instantiate(createdUnit, deployPosition, Quaternion.identity, deployTransform);
        _controllableObject = unit.GetComponent<IControllable>();
        _controllableObject.DestroyHandCoinNotDiscard();
        _controllableObject.DestroyDeployPoint();
        _controllableObject.ChangeActiveTeam();
    }
}
