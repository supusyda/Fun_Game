using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.VisualScripting;
using UnityEngine.EventSystems;


public class BuildingManager : MonoBehaviourSingleton<BuildingManager>
{
    // Start is called before the first frame update
    [SerializeField] public BuildingSO selectedBuilding;
    // [SerializeField] ContactFilter2D contactFilter;
    [SerializeField] LayerMask layerMask;

    // Update is called once per frame
    [SerializeField] private List<BuildingSO> buildingSO = new List<BuildingSO>();
    [SerializeField] private Transform buildingTemplate;

    private void Start()
    {
        if (buildingSO.Count == 0) return;
        //     foreach (BuildingSO item in buildingSO)
        //     {
        //         Destroy(item.prefab.gameObject);
        //     }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedBuilding != null && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
            if (!CanSpawnBuiding(selectedBuilding, mousePos)) return;

            Instantiate(selectedBuilding.prefab, mousePos, Quaternion.identity);
        }
    }
    public void SetSelectedBuilding(BuildingSO building)
    {
        if(selectedBuilding == building) 
        {
            selectedBuilding = null;
            return;
        }
        selectedBuilding = building;

    }
    public bool CanSpawnBuiding(BuildingSO buildingSO, Vector3 position)
    {


        //get the  OverLapBoxCollider of the building
        BoxCollider2D boxCollider2D = buildingSO.prefab.Find("OverLapBoxCollider").GetComponent<BoxCollider2D>();
        // checking the buiding is over lap other building 
        bool isOverLapOtherBuilding = Physics2D.OverlapBox(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0, layerMask) != null;
        if (isOverLapOtherBuilding) return false;// overlap other buiding 
  
        float maxBuildingRadius = 3f;
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(position, maxBuildingRadius, layerMask);
        foreach (Collider2D collider2D in collider2Ds)
        {
            bool hasBuildInRadius = collider2D.GetComponentInParent<Building>() != null;
            if (hasBuildInRadius) return true;// not over lap and has near other build in radius 
        }
        return false;// not near other building
    }



}

