using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform selectedOjb;
    [SerializeField]
    public Crew thisUnit;
    private void Awake()
    {
        selectedOjb = transform.Find("Select");
        thisUnit = GetComponent<Crew>();
    }
    public void ClearSelect()
    {
        selectedOjb.gameObject.SetActive(false);
    }
    public void ShowSelect()
    {
        selectedOjb.gameObject.SetActive(true);
    }
    private void Update()
    {

    }
    public void SetMoveDir(Vector3 dir)
    {
        // thisUnit.Move(dir);
        thisUnit.MoveInComand(dir);
    }
}
