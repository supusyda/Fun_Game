using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UPBuildingMaxAmount", menuName = "Skill/MaxTurretAmount")]
public class UpBuildAmountSO : AbilitySO
{
    // Start is called before the first frame update


    public int plusAmount = 1;
    public override void Use(Transform transform)
    {


    }
    public override void OnBegin()
    {

    }
    public override void Update()
    {

    }
    public override void OnEnd()
    {

    }
    override public void OnUnlock()
    {
        BuildingManager.Instance.OnAddMaxBuilding(plusAmount);
    }
}
