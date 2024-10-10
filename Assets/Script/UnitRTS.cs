using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform selectedOjb;

    public Crew thisUnit;
    private void OnEnable()
    {
        selectedOjb = transform.Find("Select");
        thisUnit = GetComponent<Crew>();
        ClearSelect();
    }
    public void ClearSelect()
    {
        selectedOjb.gameObject.SetActive(false);
    }
    public void ShowSelect()
    {
        selectedOjb.gameObject.SetActive(true);
    }

    public void SetMoveDir(Vector3 dir)
    {
        // thisUnit.Move(dir);
        thisUnit.ChangeStateToComand(dir);
    }

}
