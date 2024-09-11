using System.Collections;
using System.Collections.Generic;
// using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RTSControl : MonoBehaviourSingleton<RTSControl>
{
    // Start is called before the first frame update
    Vector3 startPos;
    public Vector3 targetPos { get; private set; }
    [SerializeField] List<UnitRTS> unitRTs = new();
    Transform selectedArea;
    private void Awake()
    {
        selectedArea = transform.Find("SelectionArea");
        selectedArea.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //left mouse hold
            startPos = CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition();
        }
        // mouse hold
        if (Input.GetMouseButton(0))
        {
            selectedArea.gameObject.SetActive(true);
            Vector3 currentMousePos = CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(Mathf.Min(startPos.x, currentMousePos.x), Mathf.Min(startPos.y, currentMousePos.y));
            Vector3 upperRight = new Vector3(Mathf.Max(startPos.x, currentMousePos.x), Mathf.Max(startPos.y, currentMousePos.y));
            selectedArea.position = lowerLeft;
            selectedArea.localScale = upperRight - lowerLeft;
        }
        if (Input.GetMouseButtonUp(0))
        {

            OnMouseRelease();
            // Debug.Log(unitRTs.Count);
            // Vector3 startPos = CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition();
        }
        if (Input.GetMouseButtonDown(1))
        {

            OnMouseRightDown();

        }
    }
    void OnMouseRelease()
    {
        Collider2D[] thingInBox = Physics2D.OverlapAreaAll(startPos, CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition());
        if (unitRTs.Count > 0)
        {//clear the select indicater
            foreach (var unitRT in unitRTs)
            {
                unitRT.ClearSelect();
            }
            unitRTs.Clear();
        }
        // clear the list
        //add new unit into list
        foreach (Collider2D item in thingInBox)
        {
            UnitRTS unit = item.GetComponent<UnitRTS>();
            //only select unit with script <UnitRTS>
            if (unit != null) { unitRTs.Add(unit); unit.ShowSelect(); }
        }
        selectedArea.gameObject.SetActive(false);
    }
    void OnMouseRightDown()
    {
        if (unitRTs.Count <= 0) return;
        targetPos = CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition();
        unitRTs.ForEach(unit =>
        {
            Debug.Log(unit.thisUnit);

            unit.thisUnit.MoveInComand(targetPos);

        });
    }
    void OnDrawGizmos()
    {
        // unitRTs.ForEach(unit =>
        //    {


        //        Gizmos.DrawLine(unit.transform.position, targetPos);
        //        //    Gizmos.DrawLine(transform.position, startedPos);

        //    });
    }
    public Vector3 GetRandTargetPos()
    {
        return (Vector2)targetPos + Random.insideUnitCircle.normalized;
    }

}
