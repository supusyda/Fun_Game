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
    private int _maxBuildingCanBuild = 1;
    private int _currentBuilding = 1;

    void OnEnable()
    {

    }

    private void Start()
    {
        SetMaxBuildingCanBuild(1);
        SetCurrentBuilding(1);
        BuildingAmount.onBuildingAmountChange?.Invoke(GetCurrentBuilding(), GetMaxBuildingCanBuild());
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

            BeginBuild(mousePos);

        }
    }
    public void SetSelectedBuilding(BuildingSO building)
    {
        if (selectedBuilding == building)
        {
            selectedBuilding = null;
            return;
        }
        selectedBuilding = building;

    }
    private void BeginBuild(Vector3 buildPos)
    {
        Instantiate(selectedBuilding.prefab, buildPos, Quaternion.identity);
        SetCurrentBuilding(GetCurrentBuilding() + 1);
        BuildingAmount.onBuildingAmountChange?.Invoke(GetCurrentBuilding(), GetMaxBuildingCanBuild());

    }
    public bool CanSpawnBuiding(BuildingSO buildingSO, Vector3 position)
    {

        //get the  OverLapBoxCollider of the building
        if (_currentBuilding >= _maxBuildingCanBuild) return false;
        BoxCollider2D boxCollider2D = GetBoxCollider2D(buildingSO.prefab);
        // checking the buiding is over lap other building 
        if (IsOverlappingOtherBuilding(position, boxCollider2D)) return false;// overlap other buiding 
        float maxBuildingRadius = 3f;
        return HasNearbyBuildings(position, maxBuildingRadius);// not near other building
    }
    private bool IsBuilding(Collider2D collider)
    {
        return collider.GetComponentInParent<Building>() != null;
    }
    private bool HasNearbyBuildings(Vector3 position, float maxBuildingRadius)
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(position, maxBuildingRadius, layerMask);

        foreach (Collider2D collider in nearbyColliders)
        {
            if (IsBuilding(collider))
            {
                return true; // Found a nearby building
            }
        }
        return false; // No nearby buildings found
    }

    BoxCollider2D GetBoxCollider2D(Transform transform)
    {
        return transform.Find("OverLapBoxCollider").GetComponent<BoxCollider2D>();
    }
    bool IsOverlappingOtherBuilding(Vector3 position, BoxCollider2D boxCollider2D)
    {
        return Physics2D.OverlapBox(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0, layerMask) != null;
    }
    private void SetMaxBuildingCanBuild(int maxBuildingCanBuild)
    {
        _maxBuildingCanBuild = maxBuildingCanBuild;
    }
    public int GetMaxBuildingCanBuild()
    {
        return _maxBuildingCanBuild;
    }
    public void SetCurrentBuilding(int currentBuilding)
    {
        _currentBuilding = currentBuilding;
    }
    private int GetCurrentBuilding()
    {
        return _currentBuilding;
    }
    public void OnAddMaxBuilding(int maxBuilding)
    {
        SetMaxBuildingCanBuild(GetMaxBuildingCanBuild() + maxBuilding);
        BuildingAmount.onBuildingAmountChange?.Invoke(GetCurrentBuilding(), GetMaxBuildingCanBuild());
    }

}

